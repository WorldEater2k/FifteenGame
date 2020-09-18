using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame
{
    static class GameMechanics
    {
        static public int[,] Initialize(int size) //начальное положение чисел
        {
            var arr = new int[size, size];
            int n = size * size - 1;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = n;
                    n--;
                }
            arr[size - 1, size - 1] = size * size;
            if (size > 3)
                Swap(arr, size - 1, size - 2, size - 1, size - 3);
            return arr;
        }
        static public void DrawBoard(int[,] board, int size) //нарисовать доску
        {
            var line1 = new VerticalLine(0, size * 2, 0, '*');
            line1.Draw();
            var line2 = new VerticalLine(0, size * 2, size * 3 + 1, '*');
            line2.Draw();
            var line3 = new HorizontalLine(0, size * 3 + 1, 0, '*');
            line3.Draw();
            var line4 = new HorizontalLine(0, size * 3 + 1, size * 2, '*');
            line4.Draw();

            int xPos = 2;
            int yPos = 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.SetCursorPosition(xPos, yPos);
                    if (board[i, j] == size * size)
                        Console.Write('_');
                    else
                        Console.Write(board[i, j]);
                    xPos += 3;
                }
                xPos = 2;
                yPos += 2;
            }
        }
        static public void Swap(int[,] arr, int i1, int j1, int i2, int j2) //поменять местами 2 элемента массива
        {
            int temp = arr[i1, j1];
            arr[i1, j1] = arr[i2, j2];
            arr[i2, j2] = temp;
        }
        static public bool Check(int[,] board, int size) //проверить на выигрыш
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size - 1; j++)
                    if (board[i, j] > board[i, j + 1])
                        return false;
            for (int i = 0; i < size; i++)
                if (board[i, size - 2] > board[i, size - 1])
                    return false;
            return true;
        }
        static public int[] Find(int a, int[,] arr, int size) //найти индексы элемента в массиве
        {
            int[] indices = new int[2];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (arr[i, j] == a)
                    {
                        indices[0] = i;
                        indices[1] = j;
                        return indices;
                    }
            indices[0] = -1;
            indices[1] = -1;
            return indices;
        }
        static public bool PossibleMove(int[] indices, int zeroX, int zeroY) //возможен ли такой ход?
        {
            if (indices[0] - zeroX == 1 || indices[0] - zeroX == -1
                || indices[1] - zeroY == 1 || indices[1] - zeroY == -1)
                return true;
            return false;
        }
    }
}
