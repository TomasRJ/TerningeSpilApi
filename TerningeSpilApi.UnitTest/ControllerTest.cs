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
            var id = 1;
            var die = new Die{ Id = id, IsActive = true, Value = 5 };
            _controller.ToggleDie(id);
            die.IsActive.Should().BeFalse();
        }
        
        [Fact]
        public void ActiveDieListTest()
        {
            var id = 1;
            var die = new Die{ Id = id, IsActive = true, Value = 5 };
            _controller.DiceOnTheBoard = new List<Die> { die };
            _controller.ToggleDie(id);
            _controller.DiceOnTheBoard.Should().Contain(item => item.IsActive == false);
        }
    }
}
