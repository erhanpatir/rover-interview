using MarsRover.Models;

namespace MarsRover.Commands
{
    internal class LeftCommand : RoverCommand
    {
        public LeftCommand(Rover rover) : base(rover)
        {
        }

        public override void Do()
        {
            Rover.TurnLeft();
        }
    }
}
