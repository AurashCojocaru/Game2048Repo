using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine2048.Utils
{
    internal class Position
    {
        public Position(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
