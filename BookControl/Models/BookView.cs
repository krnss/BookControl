using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookControl.Models
{
    public class BookView
    {
        [Display(Name = "Number")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Prise")]
        public decimal Prise { get; set; }
    }
}