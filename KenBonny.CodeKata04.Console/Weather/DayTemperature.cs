namespace KenBonny.CodeKata04.Console.Weather
{
    public class DayTemperature
    {
        public DayTemperature(int day, int minTemperature, int maxTemperature)
        {
            Day = day;
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
        }

        public int Day { get; }

        public int MaxTemperature { get; }

        public int MinTemperature { get; }
    }
}