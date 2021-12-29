using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.netcore.DataFolder;
using Webapi.netcore.Model;

namespace Webapi.netcore.Repository
{
    public class BookRepository:IBookRepository
    {
        public readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Books>> GetAllBooks()
        {
            var records = await _context.books.Select(x=>new Books()
            {
                Id=x.Id,
                Name=x.Name,
                Descriptions=x.Descriptions

            }).ToListAsync();
            return  records;
        }

        public async Task<string> AddBook(Books book)
        {

             _context.books.Add(book);
            await _context.SaveChangesAsync();
            return "success";
           
        }
    }
  
}
