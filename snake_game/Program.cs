using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using snake_game.Models;
using snake_game.Services;

///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U
namespace Snake
{
    class Program
    {
        static void Main()
        {
            var screen = new Screen(16, 32);
            var console = new ConsoleService(screen.Height, screen.Width);

            var game = new GameService(console, screen);
            game.Run();
        }
    }
}