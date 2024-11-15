using Microsoft.Extensions.Options;
using System.Reflection;
using System.Security.Cryptography;

namespace GravitonEcoWeb.Services
{
    public class VersionService
    {
        private readonly string _programVersion;

        public VersionService(IConfiguration configuration)
        {
            _programVersion = configuration["ProgramVersion"];
        }

        public string GetProgramVersion()
        {
            return _programVersion;
        }

        public string GetChecksum()
        {
            var filePath = Assembly.GetExecutingAssembly().Location;
            if (!File.Exists(filePath))
                return "Файл сборки не найден";

            using (var stream = File.OpenRead(filePath))
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }

    public class AppSettings
    {
        public string ProgramVersion { get; set; }
    }
}
