using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace dotnet_crud_app.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "*Obrigatory")]
        public string Title { get; set; }
        [DisplayName("Conpleted")]
        public bool Done { get; set; }
        [DisplayName("Created in")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [DisplayName("Last Update in")]
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
        public string User { get; set; }
    }
}