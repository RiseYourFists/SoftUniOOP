using Snake.Interfaces;
using System.Linq;
using System.Threading;

namespace Snake
{
    public class Engine : IEngine
    {
        

        public void Run()
        {

            var gameState = new GameCicle();
            var map = new Map("../../../MapHolder/map.txt");
            map.ReadMapData('#', gameState);
            var render = new Render();

            var headCoords = new Coordinates(map.XAxisSize / 2, map.YAxisSize / 2);
            var head = new Head(headCoords, gameState, '֍');
            var tailCoords = new Coordinates(headCoords.XAxis--, headCoords.YAxis);
            var tail = new Tail(tailCoords, gameState, '●');
            var snake = new Snake(head, tail);

            CollisionObject[][] drawableObject =
            {
               map.Tiles.ToArray(),
               new CollisionObject[] { head },
               snake.Tail
            };


            while (!gameState.IsOver)
            {



                foreach (var drawable in drawableObject)
                {
                    render.Draw(drawable);
                }

                Thread.Sleep(200);

                render.NewFrame();
                
            }
        }
    }
}