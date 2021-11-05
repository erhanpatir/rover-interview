using MarsRover.Models;

namespace MarsRover.Commands
{
    internal class RightCommand : RoverCommand
    {
        public RightCommand(Rover rover) : base(rover)
        {
        }

        public override void Do()
        {
            Rover.TurnRight();
        }
    }
}
