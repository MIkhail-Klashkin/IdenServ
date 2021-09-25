using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtTest.EF
{
    public enum Status
    {
        Active,
        Inactive,
        InProgress,
        Failed,
        Completed,
        Closed
    }
    public enum QuestType
    {
        Search,
        Escort,
        Extermination,
        Scout,
        Guard,
        Assassination,
        Courier,
        Rescue,
        Training,
        Craft,
        Unskilled,
    }
    public class Quest
    {
        public int Id { get; set; }
        public AdventureRank QuestRank { get; set; }
        public QuestType QuestType { get; set; }
        public bool IsLegal { get; set; }
        public bool IsRepeatable { get; set; }
        public bool IsPublic { get; set; }
        public string Details { get; set; }
        public Status Status { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Adventurer> Adventurers { get; set; }
    }
}
