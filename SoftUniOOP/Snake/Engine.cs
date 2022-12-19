using Snake.Collisions;
using Snake.Interfaces;
using System.Linq;
using System.Threading;
using System;

namespace Snake
{
    public class Engine : IEngine
    {


        public void Run()
        {

            var gameState = new GameCicle();
            var map = new Map("../../../MapHolder/map.txt");
            map.ReadMapData('#', gameState);
            var render = new Render(gameState);

            var headCoords = new Coordinates(map.XAxisSize / 2, map.YAxisSize / 2);
            var head = new Head(headCoords, gameState, '֍');
            var tailCoords = new Coordinates(headCoords.XAxis, headCoords.YAxis);
            var tail = new Tail(tailCoords, gameState, '●');
            var snake = new Snake(head, tail);
            var controller = new Controller();
            var checker = new CollisionChecker();
            var food = new Food(new Coordinates(0, 0), gameState, 'F', checker);
            
            while (!gameState.IsOver)
            {
                CollisionObject[][] drawableObject =
                {
                    snake.Tail,
                    new CollisionObject[] { head, food },
                    map.Tiles.ToArray(),
                };

                CollisionObject[][] foodCollidables =
                {
                    snake.Tail,
                    new CollisionObject[] { head },
                    map.Tiles.ToArray()
                };

                CollisionObject[][] collidables =
                {
                    snake.Tail,
                    map.Tiles.ToArray(),
                    new CollisionObject[] { food }
                };


                IMoveable[] moveables =
                {
                    head,
                    snake,
                };

                if (food.NewFruit)
                {
                    snake.Add(controller.Dir);
                    food.Spawn(map.XAxisSize, map.YAxisSize, foodCollidables);
                }

                controller.Read();
                foreach (var moveable in moveables)
                {
                    controller.Move(moveable);
                }


                foreach (var drawable in drawableObject)
                {
                    render.Draw(drawable);
                }

                render.WriteStats();

                if (checker.HasCollided(collidables, snake.Head.Coordinates))
                {
                    checker.CollidedObj.OnCollisionEvent();
                }

                Thread.Sleep(150);

                render.NewFrame();

            }

            render.Draw(map.Tiles.ToArray());
            var gameOverMsg = "Game Over!";
            render.WriteAt(map.XAxisSize / 2, (map.YAxisSize / 2) - gameOverMsg.Length / 2, gameOverMsg);

            Console.ReadLine();
            render.NewFrame();
        }
    }
}