using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace MarsRoverApplication.Model
{
    public enum eDirection
    {
        N = 1,
        E = 2,
        S = 3,
        W = 4
    }

    public interface IRover
    {
        Position RoverPosition { get; set; }
        eDirection RoverDirection { get; set; }
        string RoverCommands { get; set; }
        void TurnLeft();
        void TurnRight();
        void Move();
        string ToString();

    }


    public class Rover : IRover
    {
        public Position RoverPosition { get; set; }
        public string RoverCommands { get; set; }
        public eDirection RoverDirection { get; set; }

        public Rover(Position roverPosition, string roverCommands, eDirection roverDirection)
        {
            RoverPosition = roverPosition;
            RoverCommands = roverCommands;
            RoverDirection = roverDirection;
        }

        public void Move()
        {
            if (RoverDirection == eDirection.E)
                RoverPosition.XCoordinate += 1;
            else if (RoverDirection == eDirection.W)
                RoverPosition.XCoordinate -= 1;
            else if (RoverDirection == eDirection.S)
                RoverPosition.YCoordinate -= 1;
            else if (RoverDirection == eDirection.N)
                RoverPosition.YCoordinate += 1;
            else
                throw new Exception("Incorrect direction input.");

        }

        public void TurnLeft()
        {
            if (RoverDirection == eDirection.E)
                RoverDirection = eDirection.N;
            else if (RoverDirection == eDirection.W)
                RoverDirection = eDirection.S;
            else if (RoverDirection == eDirection.S)
                RoverDirection = eDirection.E;
            else if (RoverDirection == eDirection.N)
                RoverDirection = eDirection.W;
            else
                throw new Exception("Incorrect direction input.");

        }

        public void TurnRight()
        {
            if (RoverDirection == eDirection.E)
                RoverDirection = eDirection.S;
            else if (RoverDirection == eDirection.W)
                RoverDirection = eDirection.N;
            else if (RoverDirection == eDirection.S)
                RoverDirection = eDirection.W;
            else if (RoverDirection == eDirection.N)
                RoverDirection = eDirection.E;
            else
                throw new Exception("Incorrect direction input.");
        }


        public override string ToString()
        {
            return string.Format("{0} {1} {2}", RoverPosition.XCoordinate, RoverPosition.YCoordinate, RoverDirection);
        }

    }
}
