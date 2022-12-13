using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Contracts.Controller
{
    public interface IDirection
    {
        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
            STOP
        }
    }
}
