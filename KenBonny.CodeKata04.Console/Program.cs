using CommandLine;

namespace KenBonny.CodeKata04.Console
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var parser = new Parser(settings =>
            {
                settings.EnableDashDash = true;
            });

            var parserResult = parser.ParseArguments<WeatherOptions>(args);
            
        }
    }
}