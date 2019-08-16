namespace GOLKata
{
    // using enum to represent the cell state
    // easy to read and value represents an int value 
    // starting at 0 so can use 0 for alive and 1 for dead
     public enum CellState 
        {
            Alive,
            Dead
        }
    public class Game
    {
       
        // keep game rules in one concise method
        public static CellState gameRules(CellState currentState, int liveNeighbors){
              switch (currentState)
            {
                case CellState.Alive:
                    if (liveNeighbors < 2 || liveNeighbors > 3)
                        return CellState.Dead;
                    break;
                case CellState.Dead:
                    if (liveNeighbors == 3)
                        return CellState.Alive;
                    break;
            }

            return currentState;
        }
    }
}