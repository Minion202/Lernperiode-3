using System;

class Program
{
    static void Main()
    {
        char[,] board =
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        int playerX = 0, playerY = 0;
        int playerX2 = 2, playerY2 = 2;
        int cursorX = playerX, cursorY = playerY;
        bool isPlayerXTurn = true;
        while (true)
        {
            DrawBoard(board, cursorX, cursorY);

            Console.WriteLine(isPlayerXTurn
                ? "Player X, use arrow keys to move and press Enter to confirm."
                : "Player O, use WASD keys to move and press Enter to confirm.");

            ConsoleKey key = Console.ReadKey(true).Key;

            if (isPlayerXTurn)
            {
                if (IsArrowKey(key))
                {
                    MoveCursor(key, ref cursorX, ref cursorY);
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (board[cursorY, cursorX] == ' ')
                    {
                        board[cursorY, cursorX] = 'X';
                        isPlayerXTurn = false; 
                        cursorX = playerX2;
                        cursorY = playerY2;
                    }
                    else
                    {
                        Console.WriteLine("Space is already occupied! Choose another.");
                    }
                }
            }
            else
            {
                if (IsWASDKey(key))
                {
                    MoveCursor(key, ref cursorX, ref cursorY);
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (board[cursorY, cursorX] == ' ')
                    {
                        board[cursorY, cursorX] = 'O';
                        isPlayerXTurn = true;
                        cursorX = playerX;
                        cursorY = playerY;
                    }
                    else
                    {
                        Console.WriteLine("Space is already occupied! Choose another.");
                    }
                }
            }
        }
    }

    static void MoveCursor(ConsoleKey key, ref int cursorX, ref int cursorY)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                if (cursorX > 0) cursorX--;
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                if (cursorX < 2) cursorX++;
                break;
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                if (cursorY > 0) cursorY--;
                break;
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                if (cursorY < 2) cursorY++;
                break;
        }
    }

    static bool IsArrowKey(ConsoleKey key)
    {
        return key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow ||
               key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow;
    }

    static bool IsWASDKey(ConsoleKey key)
    {
        return key == ConsoleKey.W || key == ConsoleKey.A ||
               key == ConsoleKey.S || key == ConsoleKey.D;
    }

    static void DrawBoard(char[,] board, int cursorX, int cursorY)
    {
        Console.Clear();
        Console.WriteLine(" Tic Tac Toe ");
        Console.WriteLine("----------------");

        for (int i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < 3; j++)
            {
                if (i == cursorY && j == cursorX)
                {
                    Console.Write("[");
                    Console.Write(board[i, j] == ' ' ? " " : board[i, j].ToString());
                    Console.Write("]");
                }
                else
                {
                    Console.Write(" " + (board[i, j] == ' ' ? " " : board[i, j].ToString()) + " ");
                }
                Console.Write("| ");
            }

            Console.WriteLine();
            Console.WriteLine("----------------");
        }
    }
}
