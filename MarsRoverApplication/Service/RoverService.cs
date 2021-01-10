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
        
        public bool CompareRoversPosition(List<IRover> rovers, Position position, eDirection direction)
        {
            foreach (var rover in rovers)
            {
                if (rover.RoverPosition.XCoordinate == position.XCoordinate && rover.RoverPosition.YCoordinate == position.YCoordinate
                    && rover.RoverDirection == direction)
                    return false;
                else
                    return true;
            }
            return true;

        }

    }
}
