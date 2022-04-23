using System;
using System.Collections.Generic;

namespace SamuraiScaffoldConsole
{
    public partial class Samurai
    {
        public Samurai()
        {
            BattleSamurais = new HashSet<BattleSamurai>();
            Quotes = new HashSet<Quote>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<BattleSamurai> BattleSamurais { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
