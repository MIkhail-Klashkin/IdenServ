using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtTest.EF
{
    public enum AdventureRank
    {        
        Copper, 
        Silver,
        Golden, 
        Platinum,
        Adamantite, 
        Mithril
    }
    public class Adventurer
    {
        public int Id { get; set; }
        public string AdventurerName { get; set; }
        public AdventureRank AdventurerRank { get; set; }
        public virtual  List<Quest> Quests { get; set; }
        public bool IsMentor { get; set; }
        public bool IsPartyLeader { get; set; }
        public virtual User User { get; set; }

    }
}
