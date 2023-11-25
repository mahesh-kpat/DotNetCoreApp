using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Data;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStoreApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        private readonly IConfiguration _configuration;

        public BookRepository(BookStoreContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var newBook = new Books()
            {
                Author = bookModel.Author,
                CreatedOn = DateTime.Now,
                Description = bookModel.Description,
                Title = bookModel.Title,
                LanguageId = bookModel.LanguageId,
                TotalPages = bookModel.TotalPages.HasValue ? bookModel.TotalPages.Value : 0,
                UpdatedOn = DateTime.Now,
                CoverImageUrl = bookModel.CoverImageUrl,
                BookPdfUrl = bookModel.BookPdfUrl

            };

            newBook.BookGallery = new List<BookGallery>();

            foreach (var file in bookModel.Gallery)
            {
                newBook.BookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    Url = file.Url

                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();

            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        LanguageId = book.LanguageId,
                        //Language =Convert.ToString( book.Language.Name),
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        CoverImageUrl = Convert.ToString(book.CoverImageUrl)
                    }); ;
                }
            }

            return books;

        }



        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Language = Convert.ToString(book.Language.Name),
                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageUrl = Convert.ToString(book.CoverImageUrl)


            }).Take(count).ToListAsync();



        }



        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = Convert.ToString(book.Language.Name),
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = Convert.ToString(book.CoverImageUrl),
                    Gallery = book.BookGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Url = g.Url

                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl
                }).FirstOrDefaultAsync();


        }

        public List<BookModel> SearchBook(string title, string authorname)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorname)).ToList();
        }

        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title ="MVC", Author ="Mahesh", Description = "This is the description for MVC"},
                new BookModel(){Id=2, Title ="C#", Author ="Raj" , Description = "This is the description for C#"},
                new BookModel(){Id=3, Title = "DOT NET", Author ="KUMAR", Description = "This is the description for Dot Net"},
                new BookModel(){Id=4, Title ="MVC", Author ="Mahesh", Description = "This is the description for MVC"},
                new BookModel(){Id=5, Title ="C#", Author ="Raj" , Description = "This is the description for C#"},
                new BookModel(){Id=6, Title = "DOT NET", Author ="KUMAR", Description = "This is the description for Dot Net"},
                new BookModel(){Id=7, Title ="MVC", Author ="Mahesh", Description = "This is the description for MVC"},
                new BookModel(){Id=8, Title ="C#", Author ="Raj" , Description = "This is the description for C#"},
                new BookModel(){Id=9, Title = "DOT NET", Author ="KUMAR", Description = "This is the description for Dot Net"},
                new BookModel(){Id=10, Title ="MVC", Author ="Mahesh", Description = "This is the description for MVC"},
                new BookModel(){Id=11, Title ="C#", Author ="Raj" , Description = "This is the description for C#"},
                new BookModel(){Id=12, Title = "DOT NET", Author ="KUMAR", Description = "This is the description for Dot Net"},
                new BookModel(){Id=13, Title ="MVC", Author ="Mahesh", Description = "This is the description for MVC"},
                new BookModel(){Id=14, Title ="C#", Author ="Raj" , Description = "This is the description for C#"},
                new BookModel(){Id=15, Title = "DOT NET", Author ="KUMAR", Description = "This is the description for Dot Net"}

            };
        }


        public string GetApplicationName()
        {
            return _configuration["AppName"];
            
        }
    }
}
