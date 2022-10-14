//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//     Author:  
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading;

namespace MrRainbow
{

    public class Program
    {

        private static readonly List<ConsoleColor> _colors = new()
        {
            ConsoleColor.Red,
            ConsoleColor.DarkYellow,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.DarkMagenta,
            ConsoleColor.Magenta
        };

        private static void MakeLine(int x, int y, ConsoleColor lineColor)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;

            string oneLine = new('█', Console.BufferWidth - (x * 2));
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = lineColor;
            Console.WriteLine(oneLine);
            Console.ForegroundColor = col;
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

        public static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;

            int colorCount = _colors.Count;
            int colorOffset = 0;

            for(int loop = 0; loop < 5000000; loop++)
            {
                int y = 5;

                y = MakeRainbow(colorCount, colorOffset, 10, y);
                int unused1 = MakeRainbow(colorCount, colorOffset, 10, y);

                //y = MakeRainbow(colorCount, colorOffset, 10, y);
                //y = MakeRainbow(colorCount, colorOffset, 10, y);

                colorOffset++;
                if(colorOffset > 6)
                {
                    colorOffset = 0;
                }

                Thread.Sleep(100);
            }

            Console.CursorVisible = true;
            ConsoleKeyInfo unused = Console.ReadKey();
        }

    }

}
