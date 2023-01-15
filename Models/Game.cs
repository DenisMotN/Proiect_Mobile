using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Mobile.Models
{
    public class Game
    {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string Description { get; set; }
            [OneToMany]
            public List<ListGame> ListGames { get; set; }
    }

}
