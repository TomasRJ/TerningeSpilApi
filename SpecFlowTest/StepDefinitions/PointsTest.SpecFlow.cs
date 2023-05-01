using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using TerningeSpilApi.Controllers;
using TerningeSpilApi.Model;

namespace SpecFlowTest.StepDefinitions

{
    [Binding]


    public sealed class PointsTest
    {
        private List<Die> _dice = new List<Die>();
        private IGrouping<int, Die> _equalDice;
        private _10000Controller _controller = new();
        [Given("list of dice with value (.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenListOfDice(int d1, int d2, int d3, int d4, int d5, int d6)
        {
            List<int> listOfDiceValues = new List<int> {d1,d2,d3,d4,d5,d6};
            listOfDiceValues.ForEach(d => _dice.Add(new Die { Value = d }));            
        }

        [When("the value of 3 dice are equal")]
        public void CheckThreeEqualDice()
        {
            if (_dice is not null)
                _equalDice = _dice.GroupBy(d => d.Value).Where(g => g.Count() == 3).FirstOrDefault();
        }

        [Then("the points earned should be (.*)")]
        public void CalculatePoints(int expectedValue)
        {
            _controller.CalculatePoints(_equalDice).Should().Be(expectedValue);
        }
    }
}
