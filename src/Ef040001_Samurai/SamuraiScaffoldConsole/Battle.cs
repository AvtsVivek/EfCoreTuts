using System;
using System.Collections.Generic;

namespace SamuraiScaffoldConsole
{
    public partial class Battle
    {
        public Battle()
        {
            BattleSamurais = new HashSet<BattleSamurai>();
        }

        public int BattleId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<BattleSamurai> BattleSamurais { get; set; }
    }
}
