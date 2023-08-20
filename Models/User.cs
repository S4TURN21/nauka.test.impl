using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nauka.test.impl.Models
{
    public class User
    {
        public int Id { get; set; }

        // Фамилия
        public string? LastName { get; set; }

        // Имя
        public string? FirstName { get; set; }

        // Отчество
        public string? Patronymic { get; set; }

        // Дата рождения
        public DateTime? DateOfBirth { get; set; }

        // Адрес проживания
        public string? ResidentialAddress { get; set; }

        // Отдел
        public string? Department { get; set; }

        // "О себе"
        public string? Comment { get; set; }
    }
}
