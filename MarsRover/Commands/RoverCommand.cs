using MarsRover.Models;
using System;

namespace MarsRover.Commands
{
    /// <summary>
    /// Base class of implementations of ICommand
    /// </summary>
    public abstract class RoverCommand : ICommand
    {
        public const string Move = "M";
        public const string Right = "R";
        public const string Left = "L";

        protected readonly Rover Rover;

        protected RoverCommand(Rover rover)
        {
            Rover = rover;            
        }

        public abstract void Do();

        // factory method
        public static ICommand Create(Rover rover, string command)
        {
            if (rover == null)
                throw new ArgumentNullException("Rover not found");
            if (command == Move)
                return new MoveCommand(rover);
            if (command == Right)
                return new RightCommand(rover);
            if (command == Left)
                return new LeftCommand(rover);

            throw new ArgumentOutOfRangeException("Invalid command");
        }
    }
}
