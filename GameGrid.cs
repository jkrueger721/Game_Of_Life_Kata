using System;

namespace GOLKata
{
    public class GameGrid
    {   
        // Height and Width of grid for game 
        int H;
        int W;

        // Initial grid with cell state
        public CellState[,] InitialState;
        // Next state used to update initial state
        private CellState[,] nextState;
        //Constructor initialized with specified heigth and width
        public GameGrid(int h, int w)
        {
            this.H = h;
            this.W = w; 
            // When called GameGrid will start with two grids or states
            // one public one private
            InitialState = new CellState[H,W];
            nextState = new CellState[H,W];

            for(int i = 0; i < H; i++){
                for(int j = 0; j < W; j++){
                    InitialState[i,j] = CellState.Dead;
                }
            }
        }
        //This method randomizes CellStates into our private property 'nextState'
        //Then updates our public property 'InitialState'
        //To keep things seperate only manipulate the private property
        public void RandomizeGrid(){
            Random random = new Random();

            for (int i = 0; i < H; i++){
                for ( int j = 0; j < W; j++){
                    // generates random number between 0 and 1. 
                    var next = random.Next(2);
                    var nextState = next < 1 ? CellState.Dead : CellState.Alive;
                    InitialState[i,j] = nextState;
                }
            }
        }
        // This method is to get count of Neighbors that are Alive
        // withen cells radius 
        private int GetLiveNeighbors(int x, int y)
        {
            int liveNeighbors = 0;
            //loop through adjacent indices of given index
            for(int i = -1; i <= 1; i++)
                for(int j = -1; j <= 1; j++)
                {
                    int neighborX = x + i;
                    int neighborY = y + j;

                    if (neighborX >= 0 && neighborX < H &&
                        neighborY >= 0 && neighborY < W)
                    {
                        if (InitialState[neighborX, neighborY] == CellState.Alive)
                            liveNeighbors++;
                    }
                }

            return liveNeighbors;
        }
        //this method uses the gameRules from Game class
        // to update to state of the grid cells
        public void UpdateState()
        {
            for(int i = 0; i < H; i++){
                for (int j = 0; j < W; j++){
                   var liveNeighbors = GetLiveNeighbors(i, j);
                    nextState[i, j] = 
                        Game.gameRules(InitialState[i, j], liveNeighbors);
                }
            }

             InitialState = nextState;
            nextState = new CellState[H, W];
        }

    }
}