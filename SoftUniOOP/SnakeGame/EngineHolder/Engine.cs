
using SnakeGame.Collisions;
using SnakeGame.Contracts.Controller;
using SnakeGame.Contracts.Engine;
using SnakeGame.SnakeStructure;
using SnakeGame.ControllerEngine;
using SnakeGame.MapInterpreter;
using SnakeGame.Contracts.Renderer;
using System.Linq;
using SnakeGame.Renderer;
using System.Threading;
using System.Collections;

namespace SnakeGame.EngineHolder
{
    public class Engine : IEngine
    {
        public Engine()
        {
            IsOver = false;
        }


        public bool IsOver { get; set; }


        public void Run()
        {
            //TODO: Implement Map
            var map = new Map("../../../MapHolder/map.txt");
            var head = new Head('☺');
            var tail = new Tail('■');
            var snake = new Snake(head, tail);
            var checker = new CollisionChecker();
            var controller = new Controller();
            var render = new Render();
            map.ReadMapData('#');
            head.Spawn(new Coordinates(map.Rows / 2, map.Cols / 2));
            snake.AddNewSegment(IDirection.Direction.LEFT);

            Collision[] collidables =
            {
                  
            };

            IMoveable[] moveables =
            {
                head,
                snake,
            };

            IDrawable[] drawables =
            {
                map.Tiles as IDrawable,
                head,
                snake.SnakeTail as IDrawable
            };

            while (!IsOver)
            {
                controller.Read();
                controller.Move(moveables);

                //if (checker.HasCollided(collidables, head.Coordinates)
                //   || checker.HasCollided(snake.SnakeTail.ToArray(), head.Coordinates))
                //{
                //    checker.CollidedObj.OnCollisionEvent();
                //}

                render.Draw(map.Tiles as IDrawable);
                foreach (var drawable in drawables)
                {
                    render.Draw(drawable);
                }
                Thread.Sleep(60);
            }
        }
    }
}
