using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U
namespace Snake
{
    class Program
    {
        static void DrawLine(Pixel pixel, int len, bool down)
        {
            for (int i = 0; i < len; i++)
            {
                DrawPixel(pixel);
                if (down)
                {
                    pixel.xPos++;
                }
                else
                {
                    pixel.yPos++;
                }
            }
        }
        static void DrawPixel(Pixel pixel)
        {
            Console.SetCursorPosition(pixel.xPos, pixel.yPos);
            Console.ForegroundColor = pixel.Pixel_Color;
            Console.Write("■");
        }
        static void Main(string[] args)
        {
            Random randomnummer = new Random();

            int scr_width = 32;
            int scr_height = 16;
            int score = 5;
            bool gameover = false;

            Console.WindowWidth = scr_width;
            Console.WindowHeight = scr_height;

            Pixel snake_head = new Pixel(scr_width / 2, scr_height / 2, ConsoleColor.Red);

            string movement = "RIGHT";
            List<int> snake_body_xPos = new List<int>();
            List<int> snake_body_yPos = new List<int>();
            int berryx = randomnummer.Next(0, scr_width);
            int berryy = randomnummer.Next(0, scr_height);

            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;

            string buttonpressed = "no";
            while (!gameover)
            {
                Console.Clear();
                if (snake_head.xPos == scr_width - 1 || snake_head.xPos == 0 || snake_head.yPos == scr_height - 1 || snake_head.yPos == 0)
                {
                    gameover = true;
                }

                DrawLine(new Pixel(0, 0, ConsoleColor.Magenta), scr_width, false);
                DrawLine(new Pixel(0, 0, ConsoleColor.Magenta), scr_height - 1, true);

                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == snake_head.xPos && berryy == snake_head.yPos)
                {
                    score++;
                    berryx = randomnummer.Next(1, scr_width - 2);
                    berryy = randomnummer.Next(1, scr_height - 2);
                }
                for (int i = 0; i < snake_body_xPos.Count(); i++)
                {
                    Console.SetCursorPosition(snake_body_xPos[i], snake_body_yPos[i]);
                    Console.Write("■");
                    if (snake_body_xPos[i] == snake_head.xPos && snake_body_yPos[i] == snake_head.yPos)
                    {
                        gameover = true;
                    }
                }

                Console.SetCursorPosition(snake_head.xPos, snake_head.yPos);
                Console.ForegroundColor = snake_head.Pixel_Color;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                tijd = DateTime.Now;
                buttonpressed = "no";
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        //Console.WriteLine(toets.Key.ToString());
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonpressed == "no")
                        {
                            movement = "UP";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonpressed == "no")
                        {
                            movement = "DOWN";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonpressed == "no")
                        {
                            movement = "LEFT";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonpressed == "no")
                        {
                            movement = "RIGHT";
                            buttonpressed = "yes";
                        }
                    }
                }
                snake_body_xPos.Add(snake_head.xPos);
                snake_body_yPos.Add(snake_head.yPos);
                switch (movement)
                {
                    case "UP":
                        snake_head.yPos--;
                        break;
                    case "DOWN":
                        snake_head.yPos++;
                        break;
                    case "LEFT":
                        snake_head.xPos--;
                        break;
                    case "RIGHT":
                        snake_head.xPos++;
                        break;
                }
                if (snake_body_xPos.Count() > score)
                {
                    snake_body_xPos.RemoveAt(0);
                    snake_body_yPos.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(scr_width / 5, scr_height / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(scr_width / 5, scr_height / 2 + 1);
            Console.ReadKey();
        }
        class Pixel
        {
            public Pixel(int x, int y, ConsoleColor Color)
            {
                xPos = x;
                yPos = y;
                Pixel_Color = Color;
            }
            public int xPos { get; set; }
            public int yPos { get; set; }
            public ConsoleColor Pixel_Color { get; set; }
        }
    }
}