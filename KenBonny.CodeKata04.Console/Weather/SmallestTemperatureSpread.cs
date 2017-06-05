using System.Collections.Generic;

namespace KenBonny.CodeKata04.Console.Weather
{
    public class SmallestTemperatureSpread
    {
        public SmallestTemperatureSpread(int spread, IReadOnlyCollection<int> days)
        {
            Spread = spread;
            Days = days;
        }

        public int Spread { get; }

        public IReadOnlyCollection<int> Days { get; }
    }
}