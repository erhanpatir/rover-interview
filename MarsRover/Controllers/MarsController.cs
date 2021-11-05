using MarsRover.Commands;
using MarsRover.Models;
using MarsRover.States;
using System;
using System.Collections.Generic;
using System.IO;

namespace MarsRover.Controllers
{
    public class MarsController : IController
    {
        private List<ICommand> _commands;
        public Plateau Plateau { get; private set; }

        public MarsController()
        {
            _commands = new List<ICommand>();
        }
        public void GetCommands(string input)
        {
            _commands.Clear();
            
            var reader = new StringReader(input);
            
            string line;
            var index = 0;
            
            Rover rover = null;
            
            while ((line = reader.ReadLine()) != null)
            {
                if (index == 0)
                    CreatePlateau(line);
                else if (index % 2 == 1)
                    rover = AddRoverToPlateau(line);
                else
                    GetCommands(line, rover);

                index++;
            }
        }

        public void InvokeCommands()
        {
            _commands.ForEach(command => command.Do());
        }

        private void CreatePlateau(string command)
        {
            var coordinates = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int xCoor, yCoor;

            if (coordinates.Length != 2 ||
                !Int32.TryParse(coordinates[0], out xCoor) ||
                !Int32.TryParse(coordinates[1], out yCoor))
            {
                throw new InvalidDataException(string.Format("Invalid data for creating plateau: {0}", command));
            }

            Plateau = new Plateau(xCoor + 1, yCoor + 1);
        }

        private Rover AddRoverToPlateau(string command)
        {
            var commands = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int xCoor, yCoor;
            string orientation;

            if (commands.Length != 3 ||
                !Int32.TryParse(commands[0], out xCoor) ||
                !Int32.TryParse(commands[1], out yCoor) ||
                (orientation = commands[2]).Length != 1)
            {
                throw new InvalidDataException(string.Format("Invalid data for rover {0}", command));
            }

            return Plateau.AddRover(xCoor, yCoor, RoverState.GetInstance(orientation));

        }

        private void GetCommands(string commandSet, Rover rover)
        {
            var commands = new List<ICommand>();

            foreach (char command in commandSet)
            {
                commands.Add(RoverCommand.Create(rover, command.ToString()));
            }
            _commands.AddRange(commands);            
        }
    }
}
