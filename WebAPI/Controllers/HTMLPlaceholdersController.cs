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
    public class HTMLPlaceholdersController : ControllerBase
    {
        /* Dependency Injection */
        #region Dependency Injection
        IHTMLPlaceholderService _htmlPlaceholderService;

        public HTMLPlaceholdersController(IHTMLPlaceholderService htmlPlaceholderService)
        {
            _htmlPlaceholderService = htmlPlaceholderService;
        }

        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _htmlPlaceholderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetOneHTMLPlaceholderByPlaceholderId")]
        public IActionResult GetOneHTMLPlaceholderByPlaceholderId(int placeholderId)
        {
            var result = _htmlPlaceholderService.GetOneHTMLPlaceholderByPlaceholderId(placeholderId);
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
        [HttpGet("GetAllPlaceholderDetails")]
        public IActionResult GetAllPlaceholderDetails()
        {
            var result = _htmlPlaceholderService.GetAllHTMLPlaceholderDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllHTMLPlaceholderDetailsByPlaceholderId")]
        public IActionResult GetAllHTMLPlaceholderDetailsByPlaceholderId(int placeholderId)
        {
            var result = _htmlPlaceholderService.GetAllHTMLPlaceholderDetailsByPlaceholderId(placeholderId);
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
        public IActionResult Add(HTMLPlaceholder htmlPlaceholder)
        {
            var result = _htmlPlaceholderService.Add(htmlPlaceholder);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(HTMLPlaceholder htmlPlaceholder)
        {
            var result = _htmlPlaceholderService.Update(htmlPlaceholder);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(HTMLPlaceholder htmlPlaceholder)
        {
            var result = _htmlPlaceholderService.Delete(htmlPlaceholder);
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
