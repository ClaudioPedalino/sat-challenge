using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain
{
    public class UserTypePercentage
    {
        public static decimal NormalMoreThan100 { get; set; } = 0.12M;
        public static decimal NormalBetween10And100 { get; set; } = 0.08M;
        public static decimal SuperUser { get; set; } = 0.20M;
        public static decimal Premium { get; set; } = 2;
    }
}
