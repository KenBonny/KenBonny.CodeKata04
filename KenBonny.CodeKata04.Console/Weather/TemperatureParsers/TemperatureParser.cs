using System.Collections.Generic;
using System.Linq;

namespace KenBonny.CodeKata04.Console.Weather.TemperatureParsers
{
    public class TemperatureParser : ITemperatureParser
    {
        private readonly IWeatherRepository _weatherRepository;

        public TemperatureParser(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public SmallestTemperatureSpread FindSmallestTemperatureSpread()
        {
            var temperatureSpreads = LoadTemperatureSpreads();
            var daysGroupedBySpread = temperatureSpreads.GroupBy(x => x.Spread);
            var smallestSpread = daysGroupedBySpread.Min(x => x.Key);
            var smallestSpreadDays = daysGroupedBySpread.Where(x => x.Key == smallestSpread).SelectMany(x => x).Select(x => x.Day).ToArray();

            return new SmallestTemperatureSpread(smallestSpread, smallestSpreadDays);
        }

        private IEnumerable<TemperatureSpread> LoadTemperatureSpreads()
        {
            return _weatherRepository.LoadAllTemperatures()
                .Select(temp => new TemperatureSpread(temp.Day, temp.MaxTemperature - temp.MinTemperature));
        }
    }
}