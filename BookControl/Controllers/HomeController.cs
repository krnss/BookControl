using BookControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookControl.Controllers
{
    
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            //db.Autors.Add(new Autor() { Name = "Ass", Surname = "Bor" });
            //db.Books.Add(new Book() { Name = "xest 002", AutorId = 1, Description = "qwertyqwertyqwertyqwerty", Prise = 200 });
            //db.Autors.Add(new Autor() { Name = "Mukola", Surname = "Bor" });
            //db.Books.Add(new Book() { Name = "foret", AutorId = 2, Description = "qwertyqwertyqwertyqwerty", Prise = 145 });
            //db.Books.Add(new Book() { Name = "Ser Tor", AutorId = 1, Description = "qwertyqwertyqwertyqwerty", Prise = 300 });

            //db.SaveChanges();
            var v = ToBookView(db.Books.ToList());
            return View(v);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task DeleteAsync(int id)
        {
            Book book = await db.Books.FindAsync(id);
            db.Books.Remove(book);
            await db.SaveChangesAsync();

        }
        public async Task EditAsync(int id,string name,string autor,string description,string prise)
        {
            var aid = db.Autors.Where(_ => _.Name+" "+_.Surname == autor).FirstOrDefault().Id;
            decimal p = Convert.ToDecimal(prise);

            db.Books.FindAsync(id).Result.Copy(name, aid, description, p);

            await db.SaveChangesAsync();

        }

        public List<BookView> ToBookView(List<Book> lb)
        {
            List<BookView> books = new List<BookView>();

            foreach (var item in lb)
            {
                books.Add(new BookView() { 
                    Id=item.Id,
                    Name=item.Name,
                    Autor=db.Autors.Where(_=>_.Id==item.AutorId).FirstOrDefault().FullName,
                    Description=item.Description,
                    Prise=item.Prise
                });
            }

            return books;
        }
    }
}