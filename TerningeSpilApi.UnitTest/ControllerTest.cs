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
    }
}
