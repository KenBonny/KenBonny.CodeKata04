using KenBonny.CodeKata04.Console.Requests;
using MediatR;

namespace KenBonny.CodeKata04.Console.Weather
{
    public class SmallestTemperatureHandler : IRequestHandler<FindSmallestWeatherSpreadRequest>

    {
        public void Handle(FindSmallestWeatherSpreadRequest message)
        {
            
        }
    }
}