using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerningeSpilApi;
using TerningeSpilApi.Controllers;


namespace SpecFlowTest.StepDefinitions

{
    [Binding]


    public sealed class PointsTest

    {
        private _10000Controller _controller = new();
        private List<Die> _dice = new List<Die>();
        private IGrouping<int, Die>? _equalDice;

        [Given(@"list of dice with value (.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenListOfDice(int p0, int p1, int p2, int p3, int p4, int p5)
        {
            _dice.Add(new Die { Value = p0 });
            _dice.Add(new Die { Value = p1 });
            _dice.Add(new Die { Value = p2 });
            _dice.Add(new Die { Value = p3 });
            _dice.Add(new Die { Value = p4 });
            _dice.Add(new Die { Value = p5 });
        }

        [When(@"the value of (.*) dice are equal")]

        public void CheckThreeEqualDice(string values)
        {

            _equalDice = _dice.GroupBy(d => d.Value).Where(g => g.Count() == 3).FirstOrDefault();
        }

        [Then(@"the points earned should be (.*)")]
        public void CalculatePoints(int expected)
        {
            _controller.CalculatePoints(_equalDice).Should().Be(expected);
        }
    }
}
