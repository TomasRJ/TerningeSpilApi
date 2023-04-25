using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerningeSpilApi.Controllers;
using FluentAssertions;

namespace TerningeSpilApi.UnitTest
{
    public class ControllerTest
    {
        _10000Controller _controller = new _10000Controller();

        [Fact]
        public void TestGetDice()
        {
            _controller.GetDice().Count.Should().Be(6);
        }
        [Fact]
        public void ToggleDieTest()
        {
            int id = 1;
            var die = new Die{ Id = id, IsActive = true, Value = 5 };
            _controller.ToggleDie(id, new List<Die> { die });
            die.IsActive.Should().BeFalse();
        }
    }
}
