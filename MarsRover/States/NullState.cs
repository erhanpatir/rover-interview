using MarsRover.Models;

namespace MarsRover.States
{
    internal class NullState : RoverState
    {
        public static readonly IState Instance = new NullState();
        private NullState() : base("NULL")
        {
        }

        public override void Move(Rover rover)
        {
           
        }

        public override void TurnLeft(Rover rover)
        {
           
        }

        public override void TurnRight(Rover rover)
        {
            
        }

        public override void Stop(Rover rover)
        {
           
        }
    }
}
