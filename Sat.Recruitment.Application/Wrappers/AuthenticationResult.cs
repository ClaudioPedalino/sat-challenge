using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Wrappers
{
    public record AuthenticationResult(string Token, IEnumerable<string> ErrorMessages) { }
}
