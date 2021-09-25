using JwtTest.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class AdventurerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя является обязательным")]
        [DisplayName("Имя")]
        public string AdventurerName { get; set; }
        [Required(ErrorMessage = "Ранг является обязательным")]
        [DisplayName("Ранг")]
        public AdventureRank AdventurerRank { get; set; }
        [Required(ErrorMessage = "Раса является обязательной")]
        [DisplayName("Раса")]
        public Race Race { get; set; }
        [Required(ErrorMessage = "Страна местонахождения является обязательной")]
        [DisplayName("Страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Населённый пункт является обязательным")]
        [DisplayName("Населённый пункт")]
        public string City { get; set; }
        [DisplayName("Принятые квесты:")]
        public virtual List<Quest> Quests { get; set; }
    }
}
