using JwtTest.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class QuestModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Ранг")]
        public AdventureRank QuestRank { get; set; }
        [Required]
        [DisplayName("Тип")]
        public QuestType QuestType { get; set; }
        [Required]
        [DisplayName("Описание")]
        [StringLength(200)]
        public string Details { get; set; }
        [Required]
        [DisplayName("Статус")]
        public Status Status { get; set; }
        [Required]
        [DisplayName("Задание выдал:")]
        public virtual Client Client { get; set; }       
        [DisplayName("Задание Принял(и):")]
        public virtual List<AdventurerModel> Adventurers { get; set; }
    }
}
