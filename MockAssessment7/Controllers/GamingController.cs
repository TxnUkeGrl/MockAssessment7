using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockAssessment7.Models;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAssessment7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingController : ControllerBase
    {
        GameDB DB = new GameDB();

        //1. GET: api/gaming/players
        [HttpGet("players")] //notating the players endpoint
        public List<Player> GetPlayers() //name of method does NOT matter as it relies on the Http Route endpoint
        {
            return DB.Players;
        }

        //2. GET: api/gaming/classes
        [HttpGet("classes")]
        public List<PlayerClass> GetPlayerClasses()
        {
            return DB.PlayerClasses;
        }

        //3.
        [HttpGet("playersminlevel/{level}")]
        public List<Player> GetPlayersAboveMin(int level) //method's parameter HAS TO MATCH the Route
        {
            var minPlayers = new List<Player>();

            foreach (var player in DB.Players)
            {
                if (player.Level >= level)
                {
                    minPlayers.Add(player);
                }
            }
            return minPlayers;
        }

        //4. (HINT: google sorting object in C# by property - descending)
        [HttpGet("playersortlevel")]
        public List<Player> SortPlayerLevel()
        {
            var playerLevels = new List<Player>();

            foreach (var player in DB.Players)
            {
                playerLevels.Add(player);
            }

            var sortedLevels = playerLevels.OrderByDescending(player => player.Level).ToList();

            return sortedLevels;
        }

        //5.
        [HttpGet("playersofclass/{name}")]
        public List<Player> GetPlayersByClass(string name)
        {
            var classPlayers = new List<Player>();

            foreach (var player in DB.Players)
            {
                if (player.CurrentClass.Name.ToUpper() == name.ToUpper())
                {
                    classPlayers.Add(player);
                }
            }

            return classPlayers;
        }

        //6.
        [HttpGet("playersoftype/{type}")]
        public List<Player> GetPlayersByType(string type)
        {
            var typePlayers = new List<Player>();

            foreach (var player in DB.Players)
            {
                if(player.CurrentClass.Type.ToUpper() == type.ToUpper())
                {
                    typePlayers.Add(player);
                }
            }
            return typePlayers;
        }

        //7.
        [HttpGet("allplayedclasses")]
        public List<PlayerClass> GetUsedPlayers()
        {
            var usedClass = new List<PlayerClass>();

            foreach (var player in DB.Players)
            {
                usedClass.Add(player.CurrentClass);
            }

            return usedClass.DistinctBy(c => c.Name).ToList();
        }
    }
}
