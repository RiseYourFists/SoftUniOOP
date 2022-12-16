
using SnakeGame.Collisions;
using SnakeGame.Contracts.Controller;
using SnakeGame.Contracts.Engine;
using SnakeGame.SnakeStructure;
using SnakeGame.ControllerEngine;
using SnakeGame.MapInterpreter;

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


            Collision[] collidables =
            {
                map.Tiles as Collision,
            };

            IMoveable[] moveables =
            {
                head,
                snake,
            };

            var controller = new Controller();
            while (!IsOver)
            {
                controller.Read();
                controller.Move(moveables);

                if (checker.HasCollided(collidables, head.Coordinates) || checker.HasCollided(snake.SnakeTail, head.Coordinates))
                {
                    checker.CollidedObj.OnCollisionEvent(); //TODO: Implement OnCollisionEvent
                }

                //TODO: Implement Drawer
            }
        }
    }
}
