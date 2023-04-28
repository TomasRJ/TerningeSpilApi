using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerningeSpilApi;


namespace SpecFlowTest.StepDefinitions

{
    [Binding]


    public sealed class PointsTest

    {
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

        [Then(@"the points earned should be the dice value multiplied by (.*)")]

        public void CalculatePoints(int multiply)
        {
            int points;
            if (_equalDice is not null && _equalDice.Select(d => d.Value).FirstOrDefault() is not 1)
            {
                points = _equalDice.Select(d => d.Value).FirstOrDefault() * multiply;
            }
            else if (_equalDice is not null && _equalDice.Select(d => d.Value).FirstOrDefault() is 1)
            {
                points = 1000;
            }
        }
    }
}
