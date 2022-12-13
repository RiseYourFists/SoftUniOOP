using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Contracts.Coordination
{
    public interface ICoordinateComparator
    {
        bool Compare(ICoordinates that);
    }
}
