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
    public class PlaceholdersController : ControllerBase
    {
        /* Dependency Injection */
        #region Dependency Injection
        IPlaceholderService _placeholderService;

        public PlaceholdersController(IPlaceholderService placeholderService)
        {
            _placeholderService = placeholderService;
        }


        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _placeholderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //Bu alan HTMLPlaceholders ile karıştırılmaması için yorum satırına alınmıştır.
        //Test gerektirdiğinde açılması uygundur.
        //[HttpGet("GetOnePlaceholderByPlaceholderId")]
        //public IActionResult GetOnePlaceholderByPlaceholderId(int placeholderId)
        //{
        //    var result = _placeholderService.GetOnePlaceholderByPlaceholderId(placeholderId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        [HttpPost("Add")]
        public IActionResult Add(Placeholder placeholder)
        {
            var result = _placeholderService.Add(placeholder);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Placeholder placeholder)
        {
            var result = _placeholderService.Update(placeholder);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Placeholder placeholder)
        {
            var result = _placeholderService.Delete(placeholder);
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
