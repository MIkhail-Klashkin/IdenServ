using JwtTest.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class EditAdventurerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя является обязательным")]
        [DisplayName("Имя")]
        public string AdventurerName { get; set; }
        [Required(ErrorMessage = "Ранг является обязательным")]
        [DisplayName("Ранг")]
        public AdventureRank AdventurerRank { get; set; }
    }
}
