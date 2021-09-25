using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtTest.EF
{
    public enum Sex
    {
        Male,
        Female,
        NA
    }
    public enum Race
    {
        Gnome, 
        Goliath, 
        Dwarf, 
        Dragonborn,
        Half_orc, 
        Halfing, 
        Half_elf, 
        Planetouched, 
        Human, 
        Elf, 
        Resu
    }
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Race Race { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [ForeignKey("Adventurer")]
        public int? AdventurerId { get; set; }        
        public virtual Adventurer Adventurer { get; set; }
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Person Person { get; set; }
    }
}
