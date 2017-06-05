namespace KenBonny.CodeKata04.Console.Weather
{
    internal class TemperatureSpread
    {
        public TemperatureSpread(int day, int spread)
        {
            Day = day;
            Spread = spread;
        }

        public int Day { get; }

        public int Spread { get; }
    }
}