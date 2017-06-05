using System.Collections.Generic;
using KenBonny.CodeKata04.Console.Weather;

namespace KenBonny.CodeKata04.DataAccess.Weather
{
    public class CsvWeatherRepository : IWeatherRepository
    {
        private readonly string _fileLocation;

        public CsvWeatherRepository(string fileLocation)
        {
            _fileLocation = fileLocation;
        }
        
        public IReadOnlyCollection<DayTemperature> LoadAllTemperatures()
        {
            throw new System.NotImplementedException();
        }
    }
}