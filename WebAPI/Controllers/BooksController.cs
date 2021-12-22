using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        /* Dependency Injection */
        #region Dependency Injection
        IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetOneBookByBookId")]
        public IActionResult GetOneBookByBookId(int bookId)
        {
            var result = _bookService.GetOneBookByBookId(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        [HttpGet("GetAllBookDetails")]
        public IActionResult GetAllBookDetails()
        {
            var result = _bookService.GetAllBookDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllBookDetailsByBookId")]
        public IActionResult GetAllBookDetailsByBookId(int bookId)
        {
            var result = _bookService.GetAllBookDetailsByBookId(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        [HttpPost("GetAllBookDetailsByPublisherIds")]
        public IActionResult GetAllBookDetailsByPublisherIds( int[] publisherIds)
        {
            var result = _bookService.GetAllBookDetailsByPublisherIds(publisherIds);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("GetAllBookDetailsByAuthorIdsAndPublisherIdsAndLanguageIds")]
        public IActionResult GetAllBookDetailsByAuthorIdsAndPublisherIdsAndLanguageIds(int[] authorIds, int[] publisherIds, int[] languageIds)
        {
            var result = _bookService.GetAllBookDetailsByAuthorIdsAndPublisherIdsAndLanguageIds(authorIds,publisherIds,languageIds);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        [HttpPost("Add")]
        public IActionResult AddBook(Book book)
        {
            var result = _bookService.Add(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Book book)
        {
            var result = _bookService.Update(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Book book)
        {
            var result = _bookService.Delete(book);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
        /**************** */
    }
}
