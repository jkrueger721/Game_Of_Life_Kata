using System;

namespace GOLKata
{
    public class GameGrid
    {
        int H;
        int W;

        public CellState[,] InitialState;
        private CellState[,] nextState;
        public GameGrid(int h, int w)
        {
            this.H = h;
            this.W = w; 

            InitialState = new CellState[H,W];
            nextState = new CellState[H,W];

            for(int i = 0; i < H; i++){
                for(int j = 0; j < W; j++){
                    InitialState[i,j] = CellState.Dead;
                }
            }
        }
        public void RandomizeGrid(){
            Random random = new Random();

            for (int i = 0; i < H; i++){
                for ( int j = 0; j < W; j++){

                    var next = random.Next(2);
                    var nextState = next < 1 ? CellState.Dead : CellState.Alive;
                    InitialState[i,j] = nextState;
                }
            }
        }
        private int GetLiveNeighbors(int x, int y)
        {
            int liveNeighbors = 0;
            for(int i = -1; i <= 1; i++)
                for(int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

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