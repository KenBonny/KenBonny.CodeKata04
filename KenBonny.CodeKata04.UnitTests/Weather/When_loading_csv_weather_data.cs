using System.Collections.Generic;
using System.IO;
using System.Linq;
using KenBonny.CodeKata04.Console.Weather;
using KenBonny.CodeKata04.DataAccess.Weather;
using Xunit;

namespace KenBonny.CodeKata04.UnitTests.Weather
{
    // ReSharper disable once InconsistentNaming
    public class When_loading_csv_weather_data
    {
        [Fact]
        public void Then_return_weather_data_from_memory()
        {
            DayTemperature[] dayTemperatures;
            
            using (TextReader weatherReader = new StringReader(
                @"Dy,MxT,MnT,AvT,HDDay,AvDP,1HrP TPcpn,WxType,PDir,AvSp,Dir,MxS,SkyC,MxR,Mn,R AvSLP
                    1,88,59,74,,53.8,0,F,280,9.6,270,17,1.6,93,23,1004.5
                    2,79,63,71,,46.5,0,,330,8.7,340,23,3.3,70,28,1004.5
                    3,77,55,66,,39.6,0,,350,5,350,9,2.8,59,24,1016.8"))
            {
                IWeatherRepository weatherRepository = new CsvWeatherRepository(weatherReader);
                dayTemperatures = weatherRepository.LoadAllTemperatures().ToArray();
            }
            
            Assert.Equal(3, dayTemperatures.Length);
            Assert.Equal(1, dayTemperatures[0].Day);
            Assert.Equal(88, dayTemperatures[0].MaxTemperature);
            Assert.Equal(59, dayTemperatures[0].MinTemperature);
            
            Assert.Equal(2, dayTemperatures[1].Day);
            Assert.Equal(79, dayTemperatures[1].MaxTemperature);
            Assert.Equal(63, dayTemperatures[1].MinTemperature);
        }
    }
}