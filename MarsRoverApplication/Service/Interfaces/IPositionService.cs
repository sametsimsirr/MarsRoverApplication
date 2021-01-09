using MarsRoverApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApplication.Service
{
    public interface IPositionService
    {
        Position GetPositionCoordinate(string positionDirection);
    }
}
