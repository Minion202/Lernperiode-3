using System;

class Program
{
    static void Main()
    {
        char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        DrawBoard(board);
    }

    static void DrawBoard(char[,] board)
    {
        Console.Clear();
        Console.WriteLine(" Tic Tac Toe ");
        Console.WriteLine("-------------");

        for (int i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------");
        }
    }
}