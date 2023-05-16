using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatanChallenge.Model
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Ranking { get; set; }
        public DateTime DateInscription { get; set; }

        // add multiple things like : 
        // palmares and everything
    }
}
