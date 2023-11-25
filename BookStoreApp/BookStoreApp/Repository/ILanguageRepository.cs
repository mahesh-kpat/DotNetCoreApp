using BookStoreApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}