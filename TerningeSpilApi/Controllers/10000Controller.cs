using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TerningeSpilApi.Model;

namespace TerningeSpilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _10000Controller : ControllerBase
    {
        public List<Die>? DiceOnTheBoard { get; set; }
        public int Round { get; set; }
        public int CurrentScore { get; set; } = 0;

        [HttpGet(Name = "Round")]
        public void GetDice()
        {
            var random = new Random();
            var dice = new List<Die>();
            
            if (Round == 0)
            {
                dice.AddRange(Enumerable.Range(0, 6).Select(id => new Die { Id = id, Value = random.Next(1, 7), Round = 1 }));
                Round = 1;
                DiceOnTheBoard = dice;
            }            
            
            // Sets next round
            if (DiceOnTheBoard.Any(d => d.IsActive == false))
            {                
                DiceOnTheBoard.Where(d => d.IsActive && d.Round == Round).ToList().ForEach(d => d.Round++);
                Round++;
            }
        }

        [HttpGet(Name = "ToggleDie")]
        public void ToggleDie(int id, int round)
        {
            var die = DiceOnTheBoard.FirstOrDefault(d => d.Id == id & d.Round == round);
            die.IsActive = !die.IsActive;
        }

        public void FindSet(List<Die> dice)
        {
            if (dice.GroupBy(d => d.Value).Any(g => g.Count() >= 3))
                dice.GroupBy(d => d.Value).ToList().ForEach(d => CalculatePoints(d));
        }

        public int CalculatePoints(IGrouping<int, Die> dice)
        {
            int diceValue = dice.Select(d => d.Value).FirstOrDefault();
            int roundValue = 0;
            if (dice.Count() == 3) 
            {
                if (diceValue == 1)
                    roundValue = 1000;
                else
                    roundValue = diceValue * 100;
            }
            else if (dice.Count() == 4)
            {
                if (diceValue == 1)
                    roundValue = 2000;
                else
                    roundValue = diceValue * 100 * 2;
            }
            else if (dice.Count() == 5)
            {
                if (diceValue == 1)
                    roundValue = 4000;
                else
                    roundValue = diceValue * 100 * 4;
            }
            else if (dice.Count() == 6)
            {
                if (diceValue == 1)
                    roundValue = 10000;
                else
                    roundValue = diceValue * 100 * 8;
            }

            CurrentScore += roundValue;

            return CurrentScore;
        }
    }
}
