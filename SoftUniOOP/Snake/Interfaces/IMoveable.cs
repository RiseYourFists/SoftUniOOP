using Snake.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Interfaces
{
    public interface IMoveable
    {
        void UpdatePos(Direction direction);
    }
}
