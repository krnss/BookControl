using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookControl.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; } 

        [Display(Name ="Autor")]
        public string FullName
        {
            get => Name + " " + Surname;
        }
    }
}