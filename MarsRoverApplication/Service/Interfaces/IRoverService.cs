﻿using MarsRoverApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApplication.Service
{
    public interface IRoverService
    {
        void Process(IRover rover);
        bool CompareRoversPosition(List<IRover> rovers, Position position, eDirection direction);
    }
    
}
