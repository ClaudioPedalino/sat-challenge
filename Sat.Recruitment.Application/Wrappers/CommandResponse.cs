using Sat.Recruitment.Application.Helpers;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.Wrappers
{
    public class CommandResponse
    {
        public CommandResponse()
        {
            IsSuccess = false;
            Message = string.Empty;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static CommandResponse Success(string message = "")
        {
            return new() { IsSuccess = true, Message = message };
        }

        public static CommandResponse SuccesfullyCreated<TEntity>(string message)
        {
            var customMessage = CommandResponseHelper.CreatedMessage<TEntity>(message);
            return new() { IsSuccess = true, Message = customMessage };
        }

        public static CommandResponse SuccesfullyDeleted<TEntity>()
        {
            var customMessage = CommandResponseHelper.DeleteMessage<TEntity>();
            return new() { IsSuccess = true, Message = customMessage };
        }

        public static CommandResponse Fail(string message)
            => new() { IsSuccess = false, Message = message };

        public static CommandResponse NotFound()
            => new() { IsSuccess = false, Message = "No se encontró un registro con la información enviada" };
    }
}
