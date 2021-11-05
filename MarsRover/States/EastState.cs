using MarsRover.Models;

namespace MarsRover.States
{
    internal class EastState : RoverState
    {
        public static readonly IState Instance = new EastState();
        private EastState() : base(East)
        {
        }

        public override void Move(Rover rover)
        {
            if (rover.IsOutOfPlateau(rover.XCoordinate + 1, rover.YCoordinate))
                Stop(rover);
            else
                rover.SetPosition(rover.XCoordinate + 1, rover.YCoordinate);
        }

        public override void TurnLeft(Rover rover)
        {
            rover.State = NorthState.Instance;
        }

        public override void TurnRight(Rover rover)
        {
            rover.State = SouthState.Instance;
        }

        public override void Stop(Rover rover)
        {
            LastOrientation = rover.State.Code;
            rover.State = RIPState.Instance;
            rover.Stop(LastOrientation);
        }
    }
}
