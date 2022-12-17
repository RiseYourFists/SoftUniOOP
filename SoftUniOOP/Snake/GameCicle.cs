using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameCicle : ICycle 
    {
        public GameCicle()
        {
            IsOver = false;
        }

        public bool IsOver { get; set; }

        public void GameOver()
        {
            IsOver = true;
        }
    }
}
