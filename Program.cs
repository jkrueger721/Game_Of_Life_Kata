using System;

namespace GOLKata
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 6;
            int columns = 8;
           int[,] grid = {
               {0,0,0,0,0,0,1,0},
               {1,1,1,0,0,0,1,0},
               {0,0,0,0,0,0,1,0},
               {0,0,0,0,0,0,0,0},
               {0,0,0,1,1,0,0,0},
               {0,0,0,1,1,0,0,0}
           };
            Console.WriteLine("Initial State: ");
           for(int i = 0; i < rows; i++){
               for(int j = 0; j < columns; j++){
                   if(grid[i,j] == 0){
                       Console.Write(".");
                   }else{
                       Console.Write("O");
                   }
               }Console.WriteLine();
           } Console.WriteLine();
        //    Console.WriteLine(getNumberOfAliveNeighbors(grid, rows, columns));
        } 
        // public static int getNumberOfAliveNeighbors(int[,] grid, int rows, int columns){
        //     int numberOfAliveNeighbors = 0;

        //     for(int l = 1; l < rows; l++){
        //         for(int m = 1; m < columns; m++){
        //             for(int i = -1; i <= 1; i++){
        //                 for(int j = -1;j <= 1; j++){
        //                     numberOfAliveNeighbors += grid[l + i , m + j];
        //                 }
        //             }
        //             numberOfAliveNeighbors -= grid[l,m];
        //         }
        //     }
        //     return numberOfAliveNeighbors;
        // }
        // public static int[,] setNewState(int[,] grid, int rows, int columns){
        //     int[,] newState;

        //     return newState;
        // }
    }
    
}
