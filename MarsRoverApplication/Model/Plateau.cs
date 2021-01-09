using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApplication.Model
{
    public class Plateau
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public override string ToString() => $"XPosition: {XPosition}, YPosition:{YPosition}";
    }
}
