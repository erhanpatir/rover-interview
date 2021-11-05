using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.States
{
    public class RIPState : RoverState
    {
        public static readonly IState Instance = new RIPState();
        private RIPState() : base(RIP)
        {
        }

        public override void Move(Rover rover)
        {            
        }

        public override void TurnLeft(Rover rover)
        {           
        }

        public override void TurnRight(Rover rover)
        {           
        }
        public override void Stop(Rover rover)
        {
            SetCode(rover.LastOrientation);
        }

        protected override void SetCode(string lastCode)
        {
            if(Code == RIP)
                Code = string.Format("{0} {1}", lastCode, Code);
        }
    }
}
