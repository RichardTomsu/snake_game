using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game.Models
{
    public class Pixel(Point2D position, ConsoleColor color)
    {
        public Point2D Position { get; set; } = position;
        public ConsoleColor Color { get; set; } = color;
    }
}
