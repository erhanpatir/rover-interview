using MarsRover.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Models
{
    public class Plateau
    {
        private readonly List<Rover> _rovers;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Plateau(int width, int height)
        {
            if (width < 1)
                throw new ArgumentOutOfRangeException("Width must be greater than 0.");
            if (height < 1)
                throw new ArgumentOutOfRangeException("Length must be greater than 0.");

            Width = width;
            Height = height;
            _rovers = new List<Rover>();
        }

        public Rover AddRover(int xCoor, int yCoor, IState state)
        {
            var rover = new Rover(this);
            rover.State = state;
            rover.SetPosition(xCoor, yCoor);
            _rovers.Add(rover);
            return rover;            
        }

        public Rover FindRover(int xCoor, int yCoor)
        {
            return _rovers.FirstOrDefault(r => r.XCoordinate == xCoor && r.YCoordinate == yCoor);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var rover in _rovers)
                sb.AppendLine(rover.ToString());
            return sb.ToString().Trim();
        }
    }
}
