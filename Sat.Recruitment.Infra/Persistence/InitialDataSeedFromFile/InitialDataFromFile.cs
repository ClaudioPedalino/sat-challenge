using System.IO;

namespace Sat.Recruitment.Infra.Persistence.InitialDataSeedFromFile
{
    public class InitialDataFromFile
    {
        public static StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            var fileStream = new FileStream(path, FileMode.Open);

            return new StreamReader(fileStream);
        }
    }
}
