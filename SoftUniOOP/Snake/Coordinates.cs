using Snake.Interfaces;

namespace Snake
{
    public class Coordinates : ICoordinates
    {
        public Coordinates(int xAxis, int yAxis)
        {
            XAxis = xAxis;
            YAxis = yAxis;
        }

        public int XAxis { get; set; }

        public int YAxis { get; set; }
    }
}
