using System;
using System.Collections.Generic;

namespace KenBonny.CodeKata04.Weather
{
    public interface IWeatherRepository : IDisposable
    {
        IReadOnlyCollection<DayTemperature> LoadAllTemperatures();
    }
}