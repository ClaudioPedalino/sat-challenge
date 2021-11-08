using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.Common;
using Sat.Recruitment.Infra.Extensions;
using Sat.Recruitment.Infra.Helpers;
using Sat.Recruitment.Infra.Interfaces;
using Sat.Recruitment.Infra.Persistence.EntityConfiguration;
using Sat.Recruitment.Infra.Persistence.InitialDataSeedFromFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infra.Persistence
{
    public class DataContext : DbContext, IDataContext
    {
        private IDbContextTransaction _currentTransaction;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContext(DbContextOptions<DataContext> options,
                           IHttpContextAccessor httpContextAccessor)
                           : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDelete);

            SeedInitialData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var requester = _httpContextAccessor?.HttpContext?.User?.Claims?
                .FirstOrDefault(x => x.Type == Const.UserIdClaim)?.Value;

            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified
                    || e.State == EntityState.Deleted));

            foreach (var entityEntry in entries)
            {
                entityEntry.SetDate();

                if (entityEntry.IsUpdate()) entityEntry.SetUpdateInfo(requester);
                else if (entityEntry.IsNew()) entityEntry.SetCreateInfo(requester);
                else if (entityEntry.IsDelete()) entityEntry.SetDeleteInfo(requester);
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            _currentTransaction ??= await Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            try
            {
                await SaveChangesAsync(cancellationToken);
                _currentTransaction?.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _currentTransaction?.RollbackAsync(cancellationToken);
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RetryOnExceptionAsync(Func<Task> func)
        {
            await Database.CreateExecutionStrategy().ExecuteAsync(func);
        }



        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            var seedData = GetInitialDataFromFile();
            FillInitialData(modelBuilder, seedData);
            base.OnModelCreating(modelBuilder);
        }

        private static void FillInitialData(ModelBuilder modelBuilder, List<User> seedData)
        {
            foreach (var seedUser in seedData)
            {
                modelBuilder.Entity<User>().HasData(new User[]
                {
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = seedUser.Name,
                        Email= seedUser.Email,
                        Address = seedUser.Address,
                        Phone = seedUser.Phone,
                        UserType = seedUser.UserType,
                        Money = seedUser.Money,
                        CreateBy = "Seed Initial Data",
                        LastModificationAt = DateTimeHelper.GetSystemDate(),
                    }
                });
            }
        }

        private static List<User> GetInitialDataFromFile()
        {
            var seedData = new List<User>(5);

            using (var reader = InitialDataFromFile.ReadUsersFromFile())
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var user = new User
                    {
                        Name = line.Split(',')[0],
                        Email = line.Split(',')[1],
                        Phone = line.Split(',')[2],
                        Address = line.Split(',')[3],
                        UserType = line.Split(',')[4],
                        Money = decimal.Parse(line.Split(',')[5]),
                    };
                    seedData.Add(user);
                }
            }

            return seedData;
        }
    }
}
