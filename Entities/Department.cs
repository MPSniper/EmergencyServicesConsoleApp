using PhaseOne.Interfaces;

namespace PhaseOne.Entities
{
    public abstract class Department
    {
        public void Dispatch()
        {
            Console.Clear();
            Console.WriteLine("Our forces dispatched to your location immediately!\n");
        }
    }
}
