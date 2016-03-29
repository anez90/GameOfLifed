using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {

                Grid myGrid = new Grid(10, 15);
                myGrid.Output();
                myGrid.NextGeneration();
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    running = false;
                }
            }
            Console.ReadKey();
        }
    }
}
