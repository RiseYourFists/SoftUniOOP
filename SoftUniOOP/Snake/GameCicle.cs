using Snake.Interfaces;

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
