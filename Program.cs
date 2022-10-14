using System;
using System.Collections.Generic;
using System.Threading;

namespace MrRainbow
{
    class Program
    {

        private static List<ConsoleColor> _colors = new List<ConsoleColor>()
                {
                    ConsoleColor.Red ,
                    ConsoleColor.DarkYellow,
                    ConsoleColor.Yellow,
                    ConsoleColor.Green,
                    ConsoleColor.Blue,
                    ConsoleColor.DarkMagenta,
                    ConsoleColor.Magenta
                };

        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;

            var colorCount = _colors.Count;
            var colorOffset = 0;

            for (int loop = 0; loop < 5000000; loop++)
            {
                var y = 5;

                y = MakeRainbow(colorCount, colorOffset, 10, y);
                y = MakeRainbow(colorCount, colorOffset, 10, y);
                //y = MakeRainbow(colorCount, colorOffset, 10, y);
                //y = MakeRainbow(colorCount, colorOffset, 10, y);

                colorOffset++;
                if (colorOffset > 6)
                    colorOffset = 0;

                Thread.Sleep(100);
            }

            Console.CursorVisible = true;
            Console.ReadKey();
        }

        private static int MakeRainbow(int colorCount, int colorOffset, int x, int y)
        {
            MakeLine(x, y++, _colors[colorOffset % colorCount]);
            MakeLine(x, y++, _colors[(colorOffset + 1) % colorCount]);
            MakeLine(x, y++, _colors[(colorOffset + 2) % colorCount]);
            MakeLine(x, y++, _colors[(colorOffset + 3) % colorCount]);
            MakeLine(x, y++, _colors[(colorOffset + 4) % colorCount]);
            MakeLine(x, y++, _colors[(colorOffset + 5) % colorCount]);
            MakeLine(x, y++, _colors[(colorOffset + 6) % colorCount]);

            // Black
            MakeLine(10, y++, Console.BackgroundColor);

            return y;
        }

        private static void MakeLine(int x, int y, ConsoleColor lineColor)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;

            string oneLine = new('█', Console.BufferWidth - (x * 2));
            var col = Console.ForegroundColor;
            Console.ForegroundColor = lineColor;
            Console.WriteLine(oneLine);
            Console.ForegroundColor = col;
        }
    }
}
