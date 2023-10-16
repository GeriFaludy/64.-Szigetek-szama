using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mester_szigetek_szama
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            char[][] grid = new char[N][];
            for (int i = 0; i < N; i++)
            {
                string sor = Console.ReadLine();
                grid[i] = sor.ToCharArray();
            }

            int islandCount = SzigetekSzama(grid);
            Console.WriteLine(islandCount);         
            Console.ReadKey();
        }

        static int SzigetekSzama(char[][] grid)
        {
            int N = grid.Length;
            int M = grid[0].Length;
            bool[][] latogatott = new bool[N][];
            for (int i = 0; i < N; i++)
            {
                latogatott[i] = new bool[M];
            }

            int islandCount = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (grid[i][j] == 'Z' && !latogatott[i][j])
                    {
                        islandCount++;
                        szelessegi_bejaras(grid, latogatott, i, j);
                    }
                }
            }

            return islandCount;
        }

        static void szelessegi_bejaras(char[][] grid, bool[][] latogatott, int startX, int startY)
        {
            int N = grid.Length;
            int M = grid[0].Length;

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((startX, startY));
            latogatott[startX][startY] = true;

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                for (int k = 0; k < 4; k++)
                {
                    int newX = x + dx[k];
                    int newY = y + dy[k];

                    if (newX >= 0 && newX < N && newY >= 0 && newY < M && grid[newX][newY] == 'Z' && !latogatott[newX][newY])
                    {
                        queue.Enqueue((newX, newY));
                        latogatott[newX][newY] = true;
                    }
                }
            }
        }
    }

}
   

