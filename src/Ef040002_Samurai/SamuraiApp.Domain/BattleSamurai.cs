using System;

namespace SamuraiApp.Domain;

public class BattleSamurai
{
    public int SamuraiId { get; set; }
    public int BattleId { get; set; }
    // SamuraiId and BattleId are necessary. 
    // DateJoined below is called payload.
    public DateTime DateJoined { get; set; } // 
}
