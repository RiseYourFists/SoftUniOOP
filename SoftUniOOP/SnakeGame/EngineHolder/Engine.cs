
using SnakeGame.Collisions;
using SnakeGame.Contracts.Controller;
using SnakeGame.Contracts.Engine;
using SnakeGame.SnakeStructure;
using SnakeGame.ControllerEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.EngineHolder
{
    public class Engine : IEngine
    {
        public Engine()
        {
            isOver = false;
        }

        public bool isOver { get; set; }


        public void Run()
        {
            //TODO: Implement Map

            Collision head = new Head('☺');
            Collision tail = new Tail('■');
            IMoveable snake = new Snake(head as Head, tail as Tail);
            var checker = new CollisionChecker();

            Collision[] collidables =
            {
                snake as Collision
            };

            IMoveable[] moveables =
            {
                head as IMoveable,
               snake,
            };

            var controller = new Controller();
            while (!isOver)
            {
                controller.Read();
                controller.Move(moveables);

                if (checker.HasCollided(collidables, head.Coordinates))
                {
                    checker.CollidedObj.OnCollisionEvent(); //TODO: Implement OnCollisionEvent
                }

                //TODO: Implement Drawer
            }
        }
    }
}
