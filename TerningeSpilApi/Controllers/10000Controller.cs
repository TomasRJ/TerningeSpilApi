using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TerningeSpilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _10000Controller : ControllerBase
    {
        public List<Die>? DiceOnTheBoard { get; set; }

        [HttpGet(Name = "Round")]
        public void GetDice()
        {
            var random = new Random();
            var dice = new List<Die>();
            dice.AddRange(Enumerable.Range(0,5).Select(id => new Die { Id = id, Value = random.Next(1, 7)}));

            DiceOnTheBoard = dice;
        }

        public void ToggleDie(int id)
        {
            var die = DiceOnTheBoard.FirstOrDefault(d => d.Id == id);
            die.IsActive = !die.IsActive;
        }

        public void GetValue()
        {
            var list = DiceOnTheBoard.Where(d => d.IsActive is false).ToList();
        }
    }
}
