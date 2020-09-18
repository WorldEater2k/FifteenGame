using System;

namespace FifteenGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите поиграть в пятнашки 3x3 (введите 3) или 4x4 (введите 4)?");
            int size = Convert.ToInt32(Console.ReadLine());
            while (size != 3 && size != 4)
            {
                Console.WriteLine("Ошибка! Вы должны ввести число 3 либо 4.");
                size = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();

            var array = GameMechanics.Initialize(size);
            int zeroX = size - 1;
            int zeroY = size - 1;
            GameMechanics.DrawBoard(array, size);

            while (GameMechanics.Check(array, size) == false)
            {
                Console.SetCursorPosition(0, size + 4);
                Console.WriteLine("Введите число, которое нужно сместить на свободную клетку...");
                int move = Convert.ToInt32(Console.ReadLine());
                int[] indices = GameMechanics.Find(move, array, size);
                while (indices[0] == -1)
                {
                    Console.WriteLine("Вы ввели число, которого нет в массиве! Попробуйте ещё раз.");
                    move = Convert.ToInt32(Console.ReadLine());
                    indices = GameMechanics.Find(move, array, size);
                }
                if (GameMechanics.PossibleMove(indices, zeroX, zeroY) == true)
                    GameMechanics.Swap(array, indices[0], indices[1], zeroX, zeroY);
                Console.Clear();
                zeroX = indices[0];
                zeroY = indices[1];
                GameMechanics.DrawBoard(array, size);
            }

            YouWin();
        }
        static void YouWin() //конец игры
        {
            Console.Clear();
            Console.SetCursorPosition(10,10);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Поздравляем, вы победили!!!");
            Console.CursorVisible = false;
            Console.ReadKey();
        }
    }
}
