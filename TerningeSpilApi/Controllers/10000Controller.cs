﻿using Microsoft.AspNetCore.Http;
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

        public int CalculatePoints(IGrouping<int, Die> dice)
        {
            var preCalc = dice.Select(d => d.Value).FirstOrDefault();
            if (preCalc == 1) 
                return 1000;
            else 
                return preCalc * 100;
        }
    }
}
