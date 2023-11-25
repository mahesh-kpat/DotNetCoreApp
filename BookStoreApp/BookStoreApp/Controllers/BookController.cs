using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Repository;
using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        public BookController(IBookRepository bookRepository,
            IWebHostEnvironment webHostEnvironment,
            ILanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("~/all-books")]
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("~/book-details/{id:int:min(1)}",Name ="BookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data=await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }


        [Authorize]
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {

            ViewBag.Languages = new SelectList(await _languageRepository.GetLanguages(),"Id","Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
         

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
          if(ModelState.IsValid)
            {
                
                if(bookModel.CoverPhoto !=null)
                {
                    string folder = "Books/Cover/";
                    bookModel.CoverImageUrl =   await UploadImage(folder,bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {
                    string folder = "Books/Gallery/";

                    bookModel.Gallery = new List<GalleryModel>();
                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            Url = await UploadImage(folder, file)

                        };
                        bookModel.Gallery.Add(gallery);
                    }
                                                                
                }

                if(bookModel.BookPdf !=null)
                {
                    string folder = "books/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                }



                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

           // ViewBag.Languages = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            
            folderPath += Guid.NewGuid().ToString() + '_' + file.FileName;
            
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

    }
}
