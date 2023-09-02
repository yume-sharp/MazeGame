using System;

namespace MazeGame
{
    class Program
    {
        static char[,] maze = {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', 'S', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#'},
            {'#', ' ', '#', '#', '#', ' ', '#', ' ', '#', '#'},
            {'#', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', '#'},
            {'#', ' ', '#', ' ', '#', ' ', '#', '#', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#'},
            {'#', ' ', '#', ' ', ' ', ' ', '#', ' ', 'E', '#'},
            {'#', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
        };

        static int playerX = 1, playerY = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                PrintMaze();
                ConsoleKeyInfo input = Console.ReadKey();
                MovePlayer(input.Key);

                if (maze[playerX, playerY] == 'E')
                {
                    Console.Clear();
                    Console.WriteLine("You Win!");
                    break;
                }
            }
        }

        static void PrintMaze()
        {
            Console.Clear();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (i == playerX && j == playerY)
                    {
                        Console.Write('P');
                    }
                    else
                    {
                        Console.Write(maze[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        static void MovePlayer(ConsoleKey direction)
        {
            int newX = playerX, newY = playerY;

            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    newX--;
                    break;
                case ConsoleKey.DownArrow:
                    newX++;
                    break;
                case ConsoleKey.LeftArrow:
                    newY--;
                    break;
                case ConsoleKey.RightArrow:
                    newY++;
                    break;
                default:
                    return;
            }

            if (maze[newX, newY] != '#')
            {
                playerX = newX;
                playerY = newY;
            }
        }
    }
}