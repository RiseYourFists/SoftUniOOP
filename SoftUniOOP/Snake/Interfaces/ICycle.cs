namespace Snake.Interfaces
{
    public interface ICycle
    {
        bool IsOver { get; set; }
        void GameOver();
    }
}