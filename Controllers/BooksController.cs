using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.netcore.Model;
using Webapi.netcore.Repository;

namespace Webapi.netcore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        public readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
       [HttpGet("")]
        public async Task<IActionResult> getAllBooks()
        {
            return Ok(await _bookRepository.GetAllBooks());
        }
        [HttpGet("mesba")]
        public async Task<IActionResult> getAllBooks1()
        {
            return Ok("mesbaul");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getSingleBook([FromRoute]int id)
        {
            if(id==0)
            {
                return NotFound();
            }
            var book = await _bookRepository.GetSingleBook(id);
            if(book==null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody]Books book)
        {
            if (ModelState.IsValid)
            {
               var message= await _bookRepository.AddBook(book);
                return Ok(message);

            }
                return Ok("fail");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateBook([FromRoute] int id,[FromBody] Books book)
        {
            if(id==0)
            {
                return NotFound();
            }
            await _bookRepository.UpdateBook(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteBook([FromRoute] int id)
        {
            if(id==0)
            {
                NotFound();
            }
            await _bookRepository.DeleteBook(id);
            return Ok();
        }
    }
}

