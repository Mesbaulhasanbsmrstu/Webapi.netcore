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
    [Route("api/[controller]")]
    [ApiController]
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
    }
}

