using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Grid
    {
        private bool[,] cells;
        private bool[,] snapshots;
        private int width, height;



        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.cells = new bool[width, height];
            this.snapshots = new bool[width, height];

            Random newRandom = new Random();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var nextValue = newRandom.Next(10);
                    if (nextValue < 5)

                        cells[x, y] = true;
                    else
                        cells[x, y] = false;




                }
            }
        }

        public void Output()
        {
            Console.Clear();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (cells[x, y] == true)
                        Console.BackgroundColor = ConsoleColor.Blue;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }
        }

        public void NextGeneration()
        {



            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var neighbours = CountNeighbours(x, y);
                    if (neighbours < 2)
                        cells[x, y] = false;
                    else if ((neighbours == 2 || neighbours == 3) && cells[x, y] == true)
                        cells[x, y] = true;
                    else if (neighbours > 3)
                        cells[x, y] = false;
                    else if (neighbours == 3 && cells[x, y] == false)
                        cells[x, y] = true;





                }
            }
        }

        public int CountNeighbours(int x, int y)
        {
            var result = 0;
            if ((x > 0 && y > 0) && snapshots[x - 1, y - 1] == true) result++;

            if ((y > 0) && snapshots[x, y - 1] == true) result++;
            if ((x < width - 1 && y > 0) && snapshots[x + 1, y - 1] == true) result++;

            if ((x > 0) && snapshots[x - 1, y] == true) result++;
            if ((x < width - 1) && snapshots[x + 1, y] == true) result++;

            if ((x > 0 && y < height - 1) && snapshots[x - 1, y + 1] == true) result++;
            if ((y < height - 1) && snapshots[x, y + 1] == true) result++;
            if ((x < width - 1 && y < height - 1) && snapshots[x + 1, y + 1] == true) result++;

            return result;
        }
    }
}
