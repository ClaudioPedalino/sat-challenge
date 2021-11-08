using System.Collections.Generic;

namespace Sat.Recruitment.Application.Wrappers
{
    public record AuthenticationResult(string Token, IEnumerable<string> ErrorMessages) { }
}
