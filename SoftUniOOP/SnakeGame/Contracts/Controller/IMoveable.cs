using SnakeGame.Contracts.Coordination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Contracts.Controller
{
    public interface IMoveable : IDirection
    {
        void UpdatePos(Direction direction);
    }
}
