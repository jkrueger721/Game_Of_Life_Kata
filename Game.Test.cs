using System;
using Xunit;

namespace GOLKata
{
    public class GameTest
    {
        // private readonly Game _game;

        // public GameTest()
        // {
        //     _game = new Game();
        // }
        
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
       // [InlineData(2)]
        public void CellsWithLessThanTwoLiveNeighborsDies(int value)
        {
            var currentState = CellState.Alive;
            
            var result = Game.gameRules(currentState, value);

            Assert.Equal(result, CellState.Dead );
        }
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(8)]
        public void CellsWithMoreThanThreeLiveNeighborsDies(int value)
        {
            var currentState = CellState.Alive;

            var result = Game.gameRules(currentState, value);

            Assert.Equal(result, CellState.Dead);

        }
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void CellsWithTwoOrThreeNeighborsStayAlive(int value){
            var currentState = CellState.Alive;

            var result = Game.gameRules(currentState, value);

            Assert.Equal(result, CellState.Alive);
        }
        [Fact]
        public void CellsWithExactlyThreeNeighborsBecomesAlive(){
            var currentState = CellState.Dead;

            var result = Game.gameRules(currentState, 3);

            Assert.Equal(result, CellState.Alive);
        }
    }
}
