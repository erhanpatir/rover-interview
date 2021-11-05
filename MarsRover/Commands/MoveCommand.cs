using MarsRover.Models;

namespace MarsRover.Commands
{
    internal class MoveCommand : RoverCommand
    {
        public MoveCommand(Rover rover) : base(rover)
        {
        }

        public override void Do()
        {
            Rover.Move();
        }
    }
}
