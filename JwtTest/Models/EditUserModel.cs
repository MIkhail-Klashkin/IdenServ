using JwtTest.EF;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class EditUserModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Имя пользователя является обязательным")]
        [DisplayName("Имя пользователя")]
        public string Username { get; set; }
        [DisplayName("Новый пароль")]
        public string NewPassword { get; set; }
        [DisplayName("Уровень доступа")]
        public UserRole Role { get; set; }
        [DisplayName("Загрузите Аватар")]
        [DataType(DataType.Upload)]
        public IFormFile Avatar { get; set; }
        [Required(ErrorMessage = "Имя является обязательным")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия (Постфикс, род, город)")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Раса является обязательной")]
        [DisplayName("Раса")]
        public Race Race { get; set; }
        [DisplayName("Пол")]
        public Sex Sex { get; set; }
        [DisplayName("Возраст")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Страна местонахождения является обязательной")]
        [DisplayName("Страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Населённый пункт является обязательным")]
        [DisplayName("Населённый пункт")]
        public string City { get; set; }
    }
}
