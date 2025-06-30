using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game.Models
{
    public class Snake(Pixel head, List<Pixel> body)
    {
        public Pixel Head { get; set; } = head;
        public List<Pixel> Body { get; set; } = body;

        public static Snake Initialize(Screen screen)
        {
            var head = new Pixel(new Point2D(screen.Width / 2, screen.Height / 2), ConsoleColor.DarkRed);
            var body = new List<Pixel>() { new Pixel(new Point2D((screen.Width / 2) - 1, screen.Height / 2), ConsoleColor.Red) };
            return new Snake(head, body);
        }

        public void Move(Direction direction, int score)
        {
            var newHeadPosition = GetNextHeadPosition(direction);
            Body.Add(new Pixel(new Point2D(Head.Position.X, Head.Position.Y), ConsoleColor.Red));
            Head.Position = newHeadPosition;

            if (Body.Count > score)
                Body.RemoveAt(0);
        }

        public bool IsSelfColliding() => Body.Any(pixel => pixel.Position.Equals(Head.Position));

        private Point2D GetNextHeadPosition(Direction direction)
        {
            return direction switch
            {
                Direction.Up => new Point2D(Head.Position.X, Head.Position.Y - 1),
                Direction.Down => new Point2D(Head.Position.X, Head.Position.Y + 1),
                Direction.Left => new Point2D(Head.Position.X - 1, Head.Position.Y),
                Direction.Right => new Point2D(Head.Position.X + 1, Head.Position.Y),
                _ => Head.Position
            };
        }
    }
}
