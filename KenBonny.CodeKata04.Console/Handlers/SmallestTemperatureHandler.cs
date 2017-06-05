using KenBonny.CodeKata04.Console.Requests;
using KenBonny.CodeKata04.Weather;
using MediatR;

namespace KenBonny.CodeKata04.Console.Handlers
{
    public class SmallestTemperatureHandler : IRequestHandler<FindSmallestWeatherSpreadRequest>
    {
        private readonly ITemperatureParser _temperatureParser;
        private readonly ISmallestTemperatureSpreadWriter _temperatureSpreadWriter;

        public SmallestTemperatureHandler(ITemperatureParser temperatureParser, ISmallestTemperatureSpreadWriter temperatureSpreadWriter)
        {
            _temperatureParser = temperatureParser;
            _temperatureSpreadWriter = temperatureSpreadWriter;
        }
        
        public void Handle(FindSmallestWeatherSpreadRequest message)
        {
            var smallestTemperatureSpread = _temperatureParser.FindSmallestTemperatureSpread();
            _temperatureSpreadWriter.Write(smallestTemperatureSpread);
        }
    }
}