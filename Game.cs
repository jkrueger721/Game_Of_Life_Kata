namespace GOLKata
{
    public class Game
    {
        public enum CellState 
        {
            Alive,
            Dead
        }

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