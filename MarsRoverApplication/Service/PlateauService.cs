using MarsRoverApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApplication.Service
{
    public class PlateauService : IPlateauService
    {
        public bool IsValidPosition(Plateau plateau, Position position)
        {
            if (position.XCoordinate >= 0 && position.XCoordinate <= plateau.XPosition &&
                   position.YCoordinate >= 0 && position.YCoordinate <= plateau.YPosition)
                return true;
            else
                return false;

        }

        public Plateau GetPlateauCoordinate(string plateauPoint)
        {
            var plateau = new Plateau();

            var bounds = plateauPoint.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            plateau.XPosition = Int32.Parse(bounds[0]);
            plateau.YPosition = Int32.Parse(bounds[1]);


            return plateau;
        }

    }
}
