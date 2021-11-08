using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Helpers
{
    public static class CommandResponseHelper
    {
        public static string CreatedMessage<TEntity>(string customMessage)
            => $"{typeof(TEntity).Name} {customMessage} succesfully created";

        public static string UpdateMessage<TEntity>()
            => $"{typeof(TEntity).Name} succesfully updated";

        public static string DeleteMessage<TEntity>()
            => $"{typeof(TEntity).Name} succesfully deleted";

        public static string CreateErrorMessage<TEntity>()
            => $"There was a problem trying to create current {typeof(TEntity).FullName}";

        public static string UpdateErrorMessage<TEntity>()
            => $"There was a problem trying to update current {typeof(TEntity).FullName}";

        public static string DeleteErrorMessage<TEntity>()
            => $"There was a problem trying to delete current {typeof(TEntity).FullName}";
    }
}
