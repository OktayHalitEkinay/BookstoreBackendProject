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
    public class ComponentImagesController : ControllerBase
    {
        /* Dependency Injection */
        #region Dependency Injection
        IComponentImageService _componentImageService;

        public ComponentImagesController(IComponentImageService componentImageService)
        {
            _componentImageService = componentImageService;
        }
        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _componentImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetOneComponentImageByComponentImageId")]
        public IActionResult GetOneComponentImageByComponentImageId(int componentImageId)
        {
            var result = _componentImageService.GetOneComponentImageByComponentImageId(componentImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetComponentImagesByComponentId")]
        public IActionResult GetComponentImagesByComponentId(int componentId)
        {
            var result = _componentImageService.GetComponentImagesByComponentId(componentId);
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
        public IActionResult Add(ComponentImage componentImage)
        {
            var result = _componentImageService.Add(componentImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(ComponentImage componentImage)
        {
            var result = _componentImageService.Update(componentImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("Delete")]
        public IActionResult Delete(ComponentImage componentImage)
        {
            var result = _componentImageService.Delete(componentImage);
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
