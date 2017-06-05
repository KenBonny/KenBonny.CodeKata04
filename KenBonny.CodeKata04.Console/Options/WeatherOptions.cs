using CommandLine;

namespace KenBonny.CodeKata04.Console.Options
{
    [Verb("weather", HelpText = "Display the lowest spread in weather data")]
    internal class WeatherOptions
    {
        [Option('f', "file", 
            HelpText = "The location of the data file. When not set, default data will be chosen", 
            Required = false, 
            Default = "Data\\weather.csv")]
        public string FileLocation { get; set; }
    }
}