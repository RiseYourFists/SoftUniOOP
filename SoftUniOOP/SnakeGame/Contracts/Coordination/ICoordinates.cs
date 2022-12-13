using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Contracts.Coordination
{
    public interface ICoordinates
    {
        public int XAxis { get; set; }

        public int YAxis { get; set; }
    }
}
