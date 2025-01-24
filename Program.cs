using System;

class Program
{
    static void Main()
    {
        char[,] board;
        int scoreX = 0, scoreO = 0;

        while (true)
        {
            board = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            int playerX = 0, playerY = 0;
            int playerX2 = 2, playerY2 = 2;
            int cursorX = playerX, cursorY = playerY;
            bool isPlayerXTurn = true;
            bool gameOver = false;

            while (!gameOver)
            {
                DrawBoard(board, cursorX, cursorY, scoreX, scoreO);

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

                            if (CheckWin(board, 'X'))
                            {
                                scoreX++;
                                Console.Clear();
                                Console.WriteLine("Player X wins!");
                                gameOver = true;
                            }
                            else if (CheckDraw(board))
                            {
                                Console.Clear();
                                Console.WriteLine("It's a draw!");
                                gameOver = true;
                            }
                            else
                            {
                                isPlayerXTurn = false;
                                cursorX = playerX2;
                                cursorY = playerY2;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space is already chosen! Choose another.");
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

                            if (CheckWin(board, 'O'))
                            {
                                scoreO++;
                                Console.Clear();
                                Console.WriteLine("Player O wins!");
                                gameOver = true;
                            }
                            else if (CheckDraw(board))
                            {
                                Console.Clear();
                                Console.WriteLine("It's a draw!");
                                gameOver = true;
                            }
                            else
                            {
                                isPlayerXTurn = true;
                                cursorX = playerX;
                                cursorY = playerY;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space is already chosen! Choose another.");
                        }
                    }
                }
            }

            Console.WriteLine("Press any key to start a new game...");
            Console.ReadKey();
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

    static void DrawBoard(char[,] board, int cursorX, int cursorY, int scoreX, int scoreO)
    {
        Console.Clear();
        Console.WriteLine(" Tic Tac Toe ");
        Console.WriteLine("Player X: {0} | Player O: {1}", scoreX, scoreO);
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

    static bool CheckWin(char[,] board, char player)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) return true;
            if (board[0, i] == player && board[1, i] == player && board[2, i] == player) return true;
        }

        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) return true;
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) return true;

        return false;
    }

    static bool CheckDraw(char[,] board)
    {
        foreach (char cell in board)
        {
            if (cell == ' ') return false;
        }

        return true;
    }
}
