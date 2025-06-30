using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game.Models
{
    public class Berry(Point2D position, ConsoleColor color) : Pixel(position, color)
    {
        public static Berry GenerateRandomBerry(Screen screen)
        {
            var random = new Random();

            return new Berry(new Point2D(random.Next(1, screen.Width - 2), random.Next(1, screen.Height - 2)), ConsoleColor.Green);
        }
    }
}
