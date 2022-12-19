namespace Snake.Interfaces
{
    public interface ICycle
    {
        bool IsOver { get; set; }
        public int Points { get; set; }

        void GameOver();
        void AddPoints(int amount);
    }
}