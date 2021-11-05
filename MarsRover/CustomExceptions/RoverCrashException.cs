using MarsRover.Models;
using System;

namespace MarsRover.CustomExceptions
{
    public class RoverCrashException : Exception
    {
        public RoverCrashException(Rover rover1, Rover rover2)
            : base(string.Format("Rovers crashed: {0}, {1}", rover1, rover2))
        {
            
        }
    }
}
