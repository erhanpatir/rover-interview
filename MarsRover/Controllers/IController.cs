using MarsRover.Models;

namespace MarsRover.Controllers
{
    public interface IController
    {
        Plateau Plateau { get; }
        void InvokeCommands();
        void GetCommands(string input);
    }
}
