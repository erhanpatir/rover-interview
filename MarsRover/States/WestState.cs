using MarsRover.Models;

namespace MarsRover.States
{
    internal class WestState : RoverState
    {
        public static readonly IState Instance = new WestState();
        private WestState( ) : base(West)
        {
        }

        public override void Move(Rover rover)
        {
            if (rover.IsOutOfPlateau(rover.XCoordinate - 1, rover.YCoordinate))
                Stop(rover);
            else
                rover.SetPosition(rover.XCoordinate - 1, rover.YCoordinate);
        }

        public override void TurnLeft(Rover rover)
        {
            rover.State = SouthState.Instance;
        }

        public override void TurnRight(Rover rover)
        {
            rover.State = NorthState.Instance;
        }

        public override void Stop(Rover rover)
        {
            LastOrientation = rover.State.Code;
            rover.State = RIPState.Instance;
            rover.Stop(LastOrientation);
        }
    }
}
