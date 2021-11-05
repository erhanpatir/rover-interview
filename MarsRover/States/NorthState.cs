using MarsRover.Models;

namespace MarsRover.States
{
    public class NorthState : RoverState
    {
        public static readonly IState Instance = new NorthState();
        private NorthState() : base(North)
        {
        }

        public override void Move(Rover rover)
        {
            if (rover.IsOutOfPlateau(rover.XCoordinate, rover.YCoordinate + 1))
                Stop(rover);
            else
                rover.SetPosition(rover.XCoordinate, rover.YCoordinate + 1);
        }

        public override void TurnLeft(Rover rover)
        {
            rover.State = WestState.Instance;
        }

        public override void TurnRight(Rover rover)
        {
            rover.State = EastState.Instance;
        }

        public override void Stop(Rover rover)
        {
            LastOrientation = rover.State.Code;
            rover.State = RIPState.Instance;
            rover.Stop(LastOrientation);
        }
    }
}
