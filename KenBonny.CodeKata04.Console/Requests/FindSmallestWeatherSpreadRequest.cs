using MediatR;

namespace KenBonny.CodeKata04.Console.Requests
{
    public class FindSmallestWeatherSpreadRequest : IRequest
    {
        public FindSmallestWeatherSpreadRequest(string fileLocation)
        {
            FileLocation = fileLocation;
        }

        public string FileLocation { get; }
    }
}