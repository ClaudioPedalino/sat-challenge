namespace Sat.Recruitment.Application.Wrappers
{
    public class CommandResult
    {
        public CommandResult()
        {
            IsSuccess = false;
            Message = string.Empty;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static CommandResult Success(string message = "")
        {
            return new() { IsSuccess = true, Message = message };
        }

        public static CommandResult Fail(string message)
            => new() { IsSuccess = false, Message = message };

        public static CommandResult NotFound()
            => new() { IsSuccess = false, Message = "No se encontró un registro con la información enviada" };
    }
}
