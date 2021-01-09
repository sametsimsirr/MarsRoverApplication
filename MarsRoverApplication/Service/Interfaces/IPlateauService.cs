using MarsRoverApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApplication.Service
{
    public interface IPlateauService
    {
        bool IsValidPosition(Plateau plateau, Position position);

        Plateau GetPlateauCoordinate(string plateauPoint);
    }
}
