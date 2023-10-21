using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Models;

namespace BookStoreApp.Repository
{
    public class BookRepository
    {

        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorname)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorname)).ToList();
        }

        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            { 
                new BookModel(){Id=1, Title ="MVC", Author ="Mahesh"},
                new BookModel(){Id=2, Title ="C#", Author ="Raj"},
                new BookModel(){Id=3, Title = "DOT NET", Author ="KUMAR"}
            
            };
        }
    }
}
