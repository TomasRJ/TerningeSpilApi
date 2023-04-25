using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TerningeSpilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _10000Controller : ControllerBase
    {
        public List<Die>? Dice { get; set; }
        public List<Die>? ActiveDice { get; set; }

        
        [HttpGet(Name = "Round")]
        public List<Die> GetDice()
        {
            Random random = new Random();
            var dice = new List<Die>();
            for (int i = 0; i < 6; i++)
                dice.Add(new Die() { Id = i, Value = random.Next(1,7) });
            Dice = dice;

            return dice;
        }

        public void ToggleDie(int id)
        {
            var die = Dice.FirstOrDefault(d => d.Id == id);
            if (die.IsActive)
            {
                var activeDie = ActiveDice.FirstOrDefault(d => d.Id == id);
                activeDie.IsActive = false;
                ActiveDice.Remove(activeDie);
                Dice.Add(activeDie);
            }
            else
            {
                die.IsActive = true;
                Dice.Remove(die);
                ActiveDice.Add(die);
            }
                
        }
    }
}
