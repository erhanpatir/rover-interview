using MarsRover.CustomExceptions;
using MarsRover.States;

namespace MarsRover.Models
{
    public class Rover
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate {get; private set; }       
        public IState State { get; set; }
        private readonly Plateau _plateau;
        
        public string LastOrientation { get; set; }

        internal Rover(Plateau plateau)
        {
            _plateau = plateau;
            State = NullState.Instance;
        }

        public bool IsOutOfPlateau(int xCoor, int yCoor)
        {
            return (xCoor < 0 || yCoor < 0 || xCoor >= _plateau.Width || yCoor >= _plateau.Height);
        }

        public void SetPosition(int xCoor, int yCoor)
        {           
                Rover rover = _plateau.FindRover(xCoor, yCoor);
                if (rover != null)
                    throw new RoverCrashException(this, rover);

                /*
                if (xCoor < 0 || yCoor < 0 ||
                    xCoor >= _plateau.Width ||
                    yCoor >= _plateau.Height)
                {
                    throw new RoverOutException(this);
                }
                */

                XCoordinate = xCoor;
                YCoordinate = yCoor;          
        }

        public void Move()
        {
            State.Move(this);
        }

        public void TurnLeft()
        {
            State.TurnLeft(this);
        }

        public void TurnRight()
        {
            State.TurnRight(this);
        }

        public void Stop(string code)
        {
            this.LastOrientation = code;
            State.Stop(this);           
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", XCoordinate, YCoordinate, State.Code);    
        }
    }
}
