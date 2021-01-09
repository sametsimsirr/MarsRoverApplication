using MarsRoverApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverApplication.Service
{
    public class PositionService : IPositionService
    {
        public Position GetPositionCoordinate(string positionDirection)
        {
            string[] directionList = { "W", "N", "S", "E" };
            var positionDirectionParts = positionDirection.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var position = new Position();

            position.XCoordinate = Int32.Parse(positionDirectionParts[0]);
            position.YCoordinate = Int32.Parse(positionDirectionParts[1]);

            var direction = positionDirectionParts[2];

            if (!directionList.Contains(direction))
                throw new Exception("Invalid direction input.");

            position.Direction = direction;
            return position;
        }
    }
}
