﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using KenBonny.CodeKata04.Weather;

namespace KenBonny.CodeKata04.UnitTests.Weather
{
    public class FakeWeatherRepository : IWeatherRepository
    {
        private Collection<DayTemperature> _temperatures = new Collection<DayTemperature>();

        public IReadOnlyCollection<DayTemperature> LoadAllTemperatures()
        {
            return _temperatures;
        }

        internal FakeWeatherRepository AddTemeparture(int day, int minTemperature, int maxTemperature)
        {
            var temperature = new DayTemperature(day, minTemperature, maxTemperature);
            _temperatures.Add(temperature);

            return this;
        }

        public void Dispose()
        {
            _temperatures = null;
        }
    }
}