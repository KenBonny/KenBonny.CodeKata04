using System;
using System.IO;
using System.Text;
using KenBonny.CodeKata04.Weather;
using KenBonny.CodeKata04.Weather.TemperatureSpreadWriters;
using Xunit;

namespace KenBonny.CodeKata04.UnitTests.Weather
{
    public class When_writing_smallest_temperature_spread
    {
        [Fact]
        public void Then_print_readable_text_for_1_day()
        {
            var stringWriter = new StringWriter();
            ISmallestTemperatureSpreadWriter spreadWriter = new SmallestTemperatureSpreadConsoleWriter(stringWriter);
            var smallestTemperatureSpread = new SmallestTemperatureSpread(1, new[] {1});

            spreadWriter.Write(smallestTemperatureSpread);

            var expected = $"The smallest spread is 1{Environment.NewLine}The day this occurs is 1{Environment.NewLine}";
            Assert.Equal(expected, stringWriter.ToString());
        }

        [Fact]
        public void Then_print_readable_text_for_multiple_days()
        {
            var stringWriter = new StringWriter();
            ISmallestTemperatureSpreadWriter spreadWriter = new SmallestTemperatureSpreadConsoleWriter(stringWriter);
            var smallestTemperatureSpread = new SmallestTemperatureSpread(1, new[] {1, 2});

            spreadWriter.Write(smallestTemperatureSpread);

            var expected = $"The smallest spread is 1{Environment.NewLine}The days this occurs are 1, 2{Environment.NewLine}";
            Assert.Equal(expected, stringWriter.ToString());
        }
    }
}