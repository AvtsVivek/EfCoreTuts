using System;
using System.Collections.Generic;

namespace SamuraiScaffoldConsole
{
    public partial class Samurai
    {
        public Samurai()
        {
            Quotes = new HashSet<Quote>();
            BattlesBattles = new HashSet<Battle>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }

        public virtual ICollection<Battle> BattlesBattles { get; set; }
    }
}
