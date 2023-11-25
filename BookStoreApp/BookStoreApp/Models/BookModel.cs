using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStoreApp.Enum;
using BookStoreApp.Helper;
using Microsoft.AspNetCore.Http;

namespace BookStoreApp.Models
{
    public class BookModel
    {
      
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]        
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author of your book")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 5)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please choose book language")]
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Display(Name ="Total pages of Book")]
        public int? TotalPages { get; set; }

        [Display(Name ="Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        [Display(Name = "upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
}
