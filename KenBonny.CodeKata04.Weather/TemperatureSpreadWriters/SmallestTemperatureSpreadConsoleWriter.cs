using System.IO;

namespace KenBonny.CodeKata04.Weather.TemperatureSpreadWriters
{
    public class SmallestTemperatureSpreadConsoleWriter : ISmallestTemperatureSpreadWriter
    {
        private readonly TextWriter _output;

        public SmallestTemperatureSpreadConsoleWriter(TextWriter output)
        {
            _output = output;
        }
        
        public void Write(SmallestTemperatureSpread smallestTemperatureSpread)
        {
            _output.WriteLine($"The smallest spread is {smallestTemperatureSpread.Spread.ToString()}");

            var days = string.Join(", ", smallestTemperatureSpread.Days);

            if (smallestTemperatureSpread.Days.Count == 1)
            {
                _output.WriteLine($"The day this occurs is {days}");                
            }
            else
            {
                _output.WriteLine($"The days this occurs are {days}");
            }
        }
    }
}