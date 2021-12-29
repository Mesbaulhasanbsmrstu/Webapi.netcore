using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.netcore.Model;

namespace Webapi.netcore.Repository
{
    public interface IBookRepository
    {
        Task<List<Books>> GetAllBooks();
        Task<string> AddBook(Books book);
    }
}
