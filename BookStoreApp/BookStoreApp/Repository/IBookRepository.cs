using BookStoreApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel bookModel);
        List<BookModel> DataSource();
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        List<BookModel> SearchBook(string title, string authorname);
        string GetApplicationName();

    }
}