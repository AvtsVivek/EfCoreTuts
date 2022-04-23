using System;
using System.Collections.Generic;

namespace SamuraiScaffoldConsole
{
    public partial class Battle
    {
        public Battle()
        {
            Samurais = new HashSet<Samurai>();
        }

        public int BattleId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Samurai> Samurais { get; set; }
    }
}
