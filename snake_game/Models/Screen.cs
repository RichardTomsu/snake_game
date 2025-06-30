using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game.Models
{
    public class Screen(int height, int width)
    {
        public int Height { get; } = height;
        public int Width { get; } = width;
    }
}
