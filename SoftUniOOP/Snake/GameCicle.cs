using Snake.Interfaces;

namespace Snake
{
    public class GameCicle : ICycle 
    {
        public GameCicle()
        {
            IsOver = false;
            Points = 0;
        }

        public bool IsOver { get; set; }

        public int Points { get; set; }

        public void GameOver()
        {
            IsOver = true;
        }

        public void AddPoints(int amount)
        {
            Points += amount;
        }
    }
}
