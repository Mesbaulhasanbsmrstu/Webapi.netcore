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
            var records = await _context.books.ToListAsync();
            return  records;
        }

        public async Task<Books> GetSingleBook(int id)
        {
            var record = await _context.books.Where(c => c.Id == id).FirstOrDefaultAsync();
         
            return record;

        }

        public async Task<string> AddBook(Books book)
        {
            

             _context.books.Add(book);
            await _context.SaveChangesAsync();
            return "success";
           
        }

        public async Task UpdateBook(int id,Books book)
        {
            var record = await _context.books.FindAsync(id);
            if(record!=null)
            {
                record.Name = book.Name;
                record.Descriptions = book.Descriptions;
                _context.Update(record);
                _context.SaveChangesAsync();
            }

        }

        public async Task DeleteBook(int id)
        {
            // var record = await _context.books.FindAsync(id);
            var book = new Books()
            {
                Id = id
        };
        _context.Remove(book);
        await _context.SaveChangesAsync();
          
        }
    }
  
}
