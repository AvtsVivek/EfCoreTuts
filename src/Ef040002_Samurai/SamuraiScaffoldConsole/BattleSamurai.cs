using System;
using System.Collections.Generic;

namespace SamuraiScaffoldConsole
{
    public partial class BattleSamurai
    {
        public int BattleId { get; set; }
        public int SamuraiId { get; set; }
        public DateTime DateJoined { get; set; }

        public virtual Battle Battle { get; set; } = null!;
        public virtual Samurai Samurai { get; set; } = null!;
    }
}
