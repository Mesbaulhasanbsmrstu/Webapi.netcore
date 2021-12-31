using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.netcore.Model;

namespace Webapi.netcore.Repository
{
    public interface IBookRepository
    {
        Task<List<Books>> GetAllBooks();
        Task<Books> GetSingleBook(int id);
        Task<string> AddBook(Books book);
        Task UpdateBook(int id, Books book);
        Task DeleteBook(int id);
    }
}
