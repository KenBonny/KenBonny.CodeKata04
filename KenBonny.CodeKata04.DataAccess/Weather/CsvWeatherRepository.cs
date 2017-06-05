using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using CsvHelper;
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
            var dayTemperatures = new Collection<DayTemperature>();

            using(TextReader weatherFile = File.OpenText(_fileLocation))
            using (var weatherReader = new CsvReader(weatherFile))
            {
                while (weatherReader.Read())
                {
                    var day = weatherReader.GetField<int>(0);
                    var maxTemp = weatherReader.GetField<int>(1);
                    var minTemp = weatherReader.GetField<int>(2);
                    var dayTemperature = new DayTemperature(day, maxTemp, minTemp);
                    dayTemperatures.Add(dayTemperature);
                }
            }

            return dayTemperatures;
        }
    }
}