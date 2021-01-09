using MarsRoverApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApplication.Service
{
    public class RoverService : IRoverService
    {

        public void Process(IRover rover)
        {
            foreach (var command in rover.RoverCommands)
            {
                if (command == 'M')
                    rover.Move();
                else if (command == 'L')
                    rover.TurnLeft();
                else if (command == 'R')
                    rover.TurnRight();
                else
                    throw new Exception("Invalid command input.");


            }
        }

    }
}
