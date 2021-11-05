using MarsRover.Models;
using System;

namespace MarsRover.CustomExceptions
{
    public class RoverOutException : Exception
    {
        public RoverOutException(Rover rover)
            : base(string.Format("Rover is out of plateau: {0}", rover))
        {
            
        }
    }
}
