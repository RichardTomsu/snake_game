using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game.Models
{
    public class Point2D(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;

        public override bool Equals(object? obj)
        {
            if (obj is Point2D point)
                return X == point.X && Y == point.Y;

            return false;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}
