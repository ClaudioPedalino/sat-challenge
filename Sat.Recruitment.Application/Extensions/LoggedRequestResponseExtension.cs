using Sat.Recruitment.Application.Models.LoggingModels;
using System.Collections.Generic;

namespace Sat.Recruitment.Application.Extensions
{
    public static class LoggedRequestResponseExtension
    {
        public static bool IsNotAnyOf(this LoggedRequestResponse loggedRequestResponse, List<string> ignoredEndpoints)
        {
            foreach (var item in ignoredEndpoints)
            {
                if (loggedRequestResponse.Request.Path.Contains(item))
                    return false;
            }
            return true;
        }
    }
}
