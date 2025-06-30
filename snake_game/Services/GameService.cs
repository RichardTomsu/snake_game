using snake_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game.Services
{
    public class GameService
    {
        private readonly ConsoleService console;
        private Snake snake;
        private Berry berry;
        private Direction movement;
        private int score;
        private readonly Screen screen;

        public GameService(ConsoleService console, Screen screen)
        {
            this.console = console;
            this.screen = screen;
            snake = Snake.Initialize(screen);
            berry = Berry.GenerateRandomBerry(screen);
            movement = Direction.Right;
            score = 1;
        }

        public void Run()
        {
            while (true)
            {
                console.Clear();

                if (IsCollisionWithWall(snake.Head.Position))
                    break;

                if (snake.IsSelfColliding())
                    break;

                console.DrawGame(screen, snake, berry);

                if (IsCollisionWithBerry(snake.Head.Position, berry.Position))
                {
                    score++;
                    berry = Berry.GenerateRandomBerry(screen);
                }

                DelayAndReadInput();

                snake.Move(movement, score);
            }

            console.ShowGameOver(score, screen);
        }

        private bool IsCollisionWithWall(Point2D snakeHeadPosition)
        {
            return snakeHeadPosition.X <= 0 ||
                snakeHeadPosition.X >= screen.Width - 1 ||
                snakeHeadPosition.Y <= 0 ||
                snakeHeadPosition.Y >= screen.Height - 1;
        }

        private bool IsCollisionWithBerry(Point2D snakeHeadPosition, Point2D berryPosition)
            => snakeHeadPosition.Equals(berryPosition);

        private void DelayAndReadInput()
        {
            var start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < 500)
                movement = console.ReadMoveKey(movement);
        }
    }
}
