using System.Linq;
using KenBonny.CodeKata04.Weather;
using KenBonny.CodeKata04.Weather.TemperatureParsers;
using Xunit;

namespace KenBonny.CodeKata04.UnitTests.Weather
{
    public class When_selecting_smallest_temperature_spread
    {
        [Fact]
        public void Then_expect_the_spread_with_one_day()
        {
            IWeatherRepository weatherRepository = new FakeWeatherRepository()
                .AddTemeparture(1, 20, 30)
                .AddTemeparture(2, 10, 15)
                .AddTemeparture(3, 20, 40);
            ITemperatureParser temperatureParser = new TemperatureParser(weatherRepository);

            var smallestTemperatureSpread = temperatureParser.FindSmallestTemperatureSpread();

            Assert.NotNull(smallestTemperatureSpread);
            Assert.Equal(5, smallestTemperatureSpread.Spread);

            var days = smallestTemperatureSpread.Days.ToArray();
            Assert.Equal(1, days.Length);
            Assert.Equal(2, days[0]);
        }

        [Fact]
        public void Then_expect_the_spread_with_multiple_days()
        {
            IWeatherRepository weatherRepository = new FakeWeatherRepository()
                .AddTemeparture(1, 20, 30)
                .AddTemeparture(2, 10, 15)
                .AddTemeparture(3, 20, 25);
            ITemperatureParser temperatureParser = new TemperatureParser(weatherRepository);

            var smallestTemperatureSpread = temperatureParser.FindSmallestTemperatureSpread();

            Assert.NotNull(smallestTemperatureSpread);
            Assert.Equal(5, smallestTemperatureSpread.Spread);

            var days = smallestTemperatureSpread.Days.ToArray();
            Assert.Equal(2, days.Length);
            Assert.Equal(2, days[0]);
            Assert.Equal(3, days[1]);
        }
    }
}