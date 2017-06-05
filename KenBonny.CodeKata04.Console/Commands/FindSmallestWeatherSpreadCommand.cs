namespace KenBonny.CodeKata04.Console.Commands
{
    public class FindSmallestWeatherSpreadCommand : ICommand
    {
        public FindSmallestWeatherSpreadCommand(string fileLocation)
        {
            FileLocation = fileLocation;
        }

        public string FileLocation { get; }
    }
}