using MarsRover.Commands;
using MarsRover.CustomExceptions;
using MarsRover.Models;
using MarsRover.States;
using System;
using Xunit;

namespace MarsRover.Tests
{
    public class CommandTests
    {
        public const string North = "N";
        public const string East  = "E";
        public const string South = "S";
        public const string West  = "W";

        [Fact]
        public void Rover_Turns_Right()
        {
            var plateau = new Plateau(4, 4);
            var rover = plateau.AddRover(2, 2, RoverState.GetInstance(North));
            var command = RoverCommand.Create(rover, RoverCommand.Right);
            
            command.Do();
            Assert.Equal(RoverState.GetInstance(East), rover.State);

            command.Do();
            Assert.Equal(RoverState.GetInstance(South), rover.State);

            command.Do();
            Assert.Equal(RoverState.GetInstance(West), rover.State);

            command.Do();
            Assert.Equal(RoverState.GetInstance(North), rover.State);
        }

        [Fact]
        public void Rover_Turns_Left()
        {
            var plateau = new Plateau(4, 4);
            var rover = plateau.AddRover(2, 2, RoverState.GetInstance(North));
            var command = RoverCommand.Create(rover, RoverCommand.Left);

            command.Do();
            Assert.Equal(RoverState.GetInstance(West), rover.State);

            command.Do();
            Assert.Equal(RoverState.GetInstance(South), rover.State);

            command.Do();
            Assert.Equal(RoverState.GetInstance(East), rover.State);

            command.Do();
            Assert.Equal(RoverState.GetInstance(North), rover.State);

        }

        [Fact]
        public void Rover_Moves_North()
        {
            var plateau = new Plateau(4,4);
            var rover = plateau.AddRover(2, 2, RoverState.GetInstance(North));
            var command = RoverCommand.Create(rover, RoverCommand.Move);
            command.Do();
            Assert.Equal(RoverState.GetInstance(North), rover.State);
            Assert.Equal(3, rover.YCoordinate);
            Assert.Equal(2, rover.XCoordinate);

        }

        [Fact]
        public void Rover_Moves_South()
        {
            var plateau = new Plateau(4, 4);
            var rover = plateau.AddRover(2, 2, RoverState.GetInstance(South));
            var command = RoverCommand.Create(rover, RoverCommand.Move);
            command.Do();
            Assert.Equal(RoverState.GetInstance(South), rover.State);
            Assert.Equal(1, rover.YCoordinate);
            Assert.Equal(2, rover.XCoordinate);

        }

        [Fact]
        public void Rover_Moves_East()
        {
            var plateau = new Plateau(4, 4);
            var rover = plateau.AddRover(2, 2, RoverState.GetInstance(East));
            var command = RoverCommand.Create(rover, RoverCommand.Move);
            command.Do();
            Assert.Equal(RoverState.GetInstance(East), rover.State);
            Assert.Equal(2, rover.YCoordinate);
            Assert.Equal(3, rover.XCoordinate);

        }

        [Fact]
        public void Rover_Moves_West()
        {
            var plateau = new Plateau(4, 4);
            var rover = plateau.AddRover(2, 2, RoverState.GetInstance(West));
            var command = RoverCommand.Create(rover, RoverCommand.Move);
            command.Do();
            Assert.Equal(RoverState.GetInstance(West), rover.State);
            Assert.Equal(2, rover.YCoordinate);
            Assert.Equal(1, rover.XCoordinate);
        }

        [Fact]
        public void Rover_Crashes_Others ()
        {
            var plateau = new Plateau(4, 4);
            var rover = plateau.AddRover(2, 2, RoverState.GetInstance(North));
            plateau.AddRover(3, 3, RoverState.GetInstance(South));

            var command = RoverCommand.Create(rover, RoverCommand.Move);
            command.Do();
            command = RoverCommand.Create(rover, RoverCommand.Right);
            command.Do();
            command = RoverCommand.Create(rover, RoverCommand.Move);
          
            Assert.Throws<RoverCrashException>(() => command.Do());
        }     

        [Fact]
        public void Should_Throw_OutOfRange()
        {
            var plateau = new Plateau(4, 4);
            var rover = plateau.AddRover(2, 2, RoverState.GetInstance(North));            
            
            Assert.Throws<ArgumentOutOfRangeException>(
                () => RoverCommand.Create(rover, "W") );
        }

        [Fact]
        public void Should_Throw_ArgumentNull()
        {   
            Assert.Throws<ArgumentNullException>(
                () => RoverCommand.Create(null, RoverCommand.Left));
        }
    }
}
