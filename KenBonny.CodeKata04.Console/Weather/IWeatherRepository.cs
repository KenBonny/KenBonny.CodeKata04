using System.Collections.Generic;

namespace KenBonny.CodeKata04.Console.Weather
{
    public interface IWeatherRepository
    {
        IReadOnlyCollection<DayTemperature> LoadAllTemperatures();
    }
}