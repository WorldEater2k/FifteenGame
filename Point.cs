using System;

namespace FifteenGame
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Sym { get; set; }
        public Point(int x, int y, char sym)
        {
            X = x;
            Y = y;
            Sym = sym;
        }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sym);
        }
    }
}
