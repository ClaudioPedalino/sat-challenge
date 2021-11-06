using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Infra.Persistence.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(e => e.Id)
                .HasAnnotation("Relational:ColumnName", "Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(e => e.Id);

            builder.Property(x => x.Name)
                .HasAnnotation("Relational:ColumnName", "Name")
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(x => x.Address)
               .HasAnnotation("Relational:ColumnName", "Address")
               .IsRequired()
               .HasMaxLength(70);

            builder.Property(x => x.Email)
               .HasAnnotation("Relational:ColumnName", "Email")
               .IsRequired()
               .HasMaxLength(70);

            builder.Property(x => x.Phone)
               .HasAnnotation("Relational:ColumnName", "Phone")
               .IsRequired()
               .HasMaxLength(21);

            builder.Property(x => x.UserType)
               .HasAnnotation("Relational:ColumnName", "UserType")
               .IsRequired()
               .HasMaxLength(20);

            builder.Property(x => x.Money)
               .HasAnnotation("Relational:ColumnName", "Money")
               .IsRequired()
               .HasDefaultValue(0);
        }
    }
}
