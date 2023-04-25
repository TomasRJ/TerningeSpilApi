using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TerningeSpilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _10000Controller : ControllerBase
    {
        [HttpGet(Name = "Round")]
        public List<Die> GetDice()
        {
            Random random = new Random();
            List<Die> dice = new List<Die>();
            for (int i = 0; i < 6; i++)
                dice.Add(new Die() { Id = i, Value = random.Next(1,7) });

            return dice;
        }

        public void ToggleDie(int id, List<Die> dice)
        {
            var die = dice.FirstOrDefault(d => d.Id == id);
            if (die.IsActive)
                die.IsActive = false;
            else
                die.IsActive = true;
        }
    }
}
