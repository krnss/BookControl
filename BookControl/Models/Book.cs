using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookControl.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public int AutorId { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 15)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Prise { get; set; }
    }
}