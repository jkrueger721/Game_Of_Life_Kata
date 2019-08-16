using System;
using System.Text;
namespace GOLKata
{
    class Program
    {
        //You can run this program by dotnet run
        // press enter to see next state
        // hold enter if you want to see it "come alive" 
        // you can also change grid size if you want 
        // by changing grid parameters on line 14 GameGrid();
        // enter "q" into terminal to end program. 
       static void Main(string[] args)
        {
            var grid = new GameGrid(8, 6);
            grid.RandomizeGrid();

            ShowGrid(grid.InitialState);
            //Keeps program running 
            while (Console.ReadLine() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.InitialState);
            }
        }

        private static void ShowGrid(CellState[,] currentState)
        {   //clear the console of the prevous grid
            Console.Clear();
            int x = 0;
            int rowLength = currentState.GetUpperBound(1) + 1;

            var output = new StringBuilder();

            foreach (var state in currentState)
            {   //if cell is alive it will be written as an "O" dead as "."
                output.Append(state == CellState.Alive ? "O" : "·");
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    output.AppendLine();
                }
            }
            Console.Write(output.ToString());
        }
    }
    
}
