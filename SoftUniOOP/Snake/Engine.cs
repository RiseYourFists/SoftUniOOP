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
            var tailCoords = new Coordinates(headCoords.XAxis, headCoords.YAxis);
            var tail = new Tail(tailCoords, gameState, '●');
            var snake = new Snake(head, tail);
            var controller = new Controller();
            var checker = new CollisionChecker();



            var count = 1;
            while (!gameState.IsOver)
            {
                CollisionObject[][] drawableObject =
                {
                    new CollisionObject[] { head },
                    snake.Tail,
                    map.Tiles.ToArray()
                };

                CollisionObject[][] collidables =
                {
                    snake.Tail,
                    map.Tiles.ToArray()
                };

                IMoveable[] moveables =
                {
                    head,
                    snake,
                };


                controller.Read();
                foreach (var moveable in moveables)
                {
                    controller.Move(moveable);
                }

                foreach (var drawable in drawableObject)
                {
                    render.Draw(drawable);
                }

                if (checker.HasCollided(collidables, snake.Head.Coordinates))
                {
                    checker.CollidedObj.OnCollisionEvent();
                }

                Thread.Sleep(100);

                render.NewFrame();
                if (count % 10 == 0)
                {
                    snake.Add(controller.Dir);
                }
                count++;
            }
        }
    }
}