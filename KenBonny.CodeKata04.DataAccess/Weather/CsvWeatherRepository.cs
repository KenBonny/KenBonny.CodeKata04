using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using KenBonny.CodeKata04.Console.Weather;

namespace KenBonny.CodeKata04.DataAccess.Weather
{
    public class CsvWeatherRepository : IWeatherRepository, IDisposable
    {
        private readonly TextReader _weatherFile;

        private readonly CsvConfiguration _configuration =
            new CsvConfiguration {HasHeaderRecord = true, Encoding = Encoding.UTF8};

        public CsvWeatherRepository(string fileLocation)
        {
            _weatherFile = File.OpenText(fileLocation);
        }

        public CsvWeatherRepository(TextReader weatherFile)
        {
            _weatherFile = weatherFile;
        }
        
        public IReadOnlyCollection<DayTemperature> LoadAllTemperatures()
        {
            var dayTemperatures = new Collection<DayTemperature>();

            using (var weatherCsvReader = new CsvReader(_weatherFile, _configuration))
            {
                while (weatherCsvReader.Read())
                {
                    var dayTemperature = ReadDayTemperature(weatherCsvReader);
                    dayTemperatures.Add(dayTemperature);
                }
            }

            return dayTemperatures;
        }

        private static DayTemperature ReadDayTemperature(ICsvReaderRow weatherCsvReader)
        {
            var day = weatherCsvReader.GetField<int>(0);
            var maxTemp = weatherCsvReader.GetField<int>(1);
            var minTemp = weatherCsvReader.GetField<int>(2);
            var dayTemperature = new DayTemperature(day, minTemp, maxTemp);
            return dayTemperature;
        }

        public void Dispose()
        {
            _weatherFile?.Dispose();
        }
    }
}