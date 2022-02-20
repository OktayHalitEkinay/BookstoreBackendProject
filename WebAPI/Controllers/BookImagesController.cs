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
    [ApiController]
    public class BookImagesController : ControllerBase
    {
        /* Dependency Injection */
        #region Dependency Injection
        IBookImageService _bookImageService;

        public BookImagesController(IBookImageService bookImageService)
        {
            _bookImageService = bookImageService;
        }
        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _bookImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetOneBookImageByBookImageId")]
        public IActionResult GetOneBookImageByBookImageId(int bookImageId)
        {
            var result = _bookImageService.GetOneBookImageByBookImageId(bookImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetBookImagesByBookId")]
        public IActionResult GetBookImagesByBookId(int bookId)
        {
            var result = _bookImageService.GetBookImagesByBookId(bookId);
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
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        [HttpPost("Add")]
        public IActionResult Add(BookImage bookImage)
        {
            var result = _bookImageService.Add(bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(BookImage bookImage)
        {
            var result = _bookImageService.Update(bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(BookImage bookImage)
        {
            var result = _bookImageService.Delete(bookImage);
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
