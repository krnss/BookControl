using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookControl.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Autor> Autors { get; set; }

        public System.Data.Entity.DbSet<BookControl.Models.BookView> BookViews { get; set; }
    }
}