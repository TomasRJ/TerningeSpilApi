using FluentAssertions;
using TerningeSpilApi.Controllers;

namespace TerningeSpilApi.UnitTest
{
    public class ControllerTest
    {
        _10000Controller _controller = new _10000Controller();

        [Fact]
        public void TestGetDice()
        {
            _controller.GetDice();
            _controller.DiceOnTheBoard.Count.Should().Be(6);
        }

        [Fact]
        public void ToggleDieTest()
        {
            // Start the game
            _controller.GetDice();

            // Now selecting die nr 1
            var id = 1;
            var die = _controller.DiceOnTheBoard.FirstOrDefault(d => d.Id == id);
            var round = _controller.Round;
            _controller.ToggleDie(id, round);
            die.IsActive.Should().BeFalse();
        }

        // Test for that a toggled die in a previous round is not toggable in the current round
        [Fact]
        public void NextRoundTest()
        {
            // Start the game
            _controller.GetDice();

            // Select die 3 and go to next round
            var id = 3;
            var selectedDie = _controller.DiceOnTheBoard.FirstOrDefault(d => d.Id == id);
            _controller.ToggleDie(id, _controller.Round);
            _controller.GetDice();

            // Assert that all other dice are on round 2
            _controller.DiceOnTheBoard
                .Where(d => d != selectedDie)
                .Should()
                .OnlyContain(d => d.Round == _controller.Round);

            // Assert that the selected die is not on round 2
            selectedDie.Round.Should().NotBe(_controller.Round);

            // Trying to toggle a previous toggled die should throw a NullReferenceException
            var tryTogglePreviousDie = () => _controller.ToggleDie(id, _controller.Round);
            tryTogglePreviousDie.Should().Throw<NullReferenceException>();
        }
   
    }

}
