using PhaseOne.Services;
namespace PhaseOne
{
    internal class Program
    {
        static void Main()
        {
            var myService = new MyServices();
            while (true)
            {
                myService.ConsoleCommands();
            }
        }
    }
}