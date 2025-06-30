using snake_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game.Services
{
    public class ConsoleService
    {
        public ConsoleService(int height, int width)
        {
            WindowHeight = height;
            WindowWidth = width;
            CursorVisible = false;
        }

        public void Clear() => Console.Clear();

        public void DrawGame(Screen screen, Snake snake, Berry berry)
        {
            DrawGameBoard(screen);
            DrawPixel(berry);
            DrawSnake(snake);
        }

        public Direction ReadMoveKey(Direction movement)
        {
            if (!KeyAvailable)
                return movement;

            var key = ReadKey(true).Key;

            if (key.Equals(ConsoleKey.UpArrow) && movement != Direction.Down)
                movement = Direction.Up;
            else if (key.Equals(ConsoleKey.DownArrow) && movement != Direction.Up)
                movement = Direction.Down;
            else if (key.Equals(ConsoleKey.LeftArrow) && movement != Direction.Right)
                movement = Direction.Left;
            else if (key.Equals(ConsoleKey.RightArrow) && movement != Direction.Left)
                movement = Direction.Right;

            return movement;
        }

        public void ShowGameOver(int score, Screen screen)
        {
            SetCursorPosition(screen.Width / 5, screen.Height / 2);
            WriteLine($"Game over, Score: {score}");
        }

        private void DrawGameBoard(Screen screen)
        {
            for (int x = 0; x < screen.Width; x++)
            {
                Draw(x, 0, "■", ConsoleColor.Cyan);
                Draw(x, screen.Height - 1, "■", ConsoleColor.Cyan);
            }

            for (int y = 0; y < screen.Height; y++)
            {
                Draw(0, y, "■", ConsoleColor.Cyan);
                Draw(screen.Width - 1, y, "■", ConsoleColor.Cyan);
            }
        }

        private void DrawSnake(Snake snake)
        {
            foreach (var bodyPart in snake.Body)
                DrawPixel(bodyPart);

            DrawPixel(snake.Head);
        }

        private void DrawPixel(Pixel pixel)
            => Draw(pixel.Position.X, pixel.Position.Y, "■", pixel.Color);

        private void Draw(int x, int y, string value, ConsoleColor color)
        {
            ForegroundColor = color;
            SetCursorPosition(x, y);
            Write(value);
        }
    }
}