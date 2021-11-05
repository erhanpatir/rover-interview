using MarsRover.Models;
using MarsRover.States;
using System.Text;
using Xunit;

namespace MarsRover.Tests
{
    public class ModelTests
    {
        public const string North = "N";
        public const string East = "E";
        public const string South = "S";
        public const string West = "W";

        [Fact]
        public void Create_Plateau()
        {
            var plateau = new Plateau(8, 10);
            Assert.Equal(8, plateau.Width);
            Assert.Equal(10, plateau.Height);
        }

        [Fact]
        public void Add_Rover()
        {
            var plateau = new Plateau(8, 10);
            var rover = plateau.AddRover(3, 5, RoverState.GetInstance(North));

            Assert.Equal(3, rover.XCoordinate);
            Assert.Equal(5, rover.YCoordinate);
            Assert.Equal(RoverState.GetInstance(North), rover.State);
        }

        [Fact]
        public void Get_Rover()
        {
            var plateau = new Plateau(8, 10);

            var rover1 = plateau.AddRover(3, 5, RoverState.GetInstance(North));
            var rover2 = plateau.FindRover(rover1.XCoordinate, rover1.YCoordinate);

            Assert.Equal(rover1, rover2);
        }

        [Fact]
        public void TestToString()
        {
            var plateau = new Plateau(3, 5);

            var rover1 = plateau.AddRover(1, 2, RoverState.GetInstance(North));
            var rover2 = plateau.AddRover(1, 3, RoverState.GetInstance(East));

            Assert.Equal("1 2 N", rover1.ToString());
            Assert.Equal("1 3 E", rover2.ToString());

            var sb = new StringBuilder();
            sb.AppendLine("1 2 N")
                .AppendLine("1 3 E");

            Assert.Equal(sb.ToString().Trim(), plateau.ToString());
        }
    }
}
