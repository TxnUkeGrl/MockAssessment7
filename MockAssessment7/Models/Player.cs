using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAssessment7.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public int Level { get; set; }
        public PlayerClass CurrentClass { get; set; }

        public Player(int id, string username, int lvl, PlayerClass playerClass)
        {
            this.ID = id;
            this.UserName = username;
            this.Level = lvl;
            this.CurrentClass = playerClass;
        }
    }
}
