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
    public class ComponentContentsController : ControllerBase
    {
        /* Dependency Injection */
        #region Dependency Injection
        IComponentContentService _componentContentService;

        public ComponentContentsController(IComponentContentService componentContentService)
        {
            _componentContentService = componentContentService;
        }


        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _componentContentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetOneComponentContentByComponentContentId")]
        public IActionResult GetOneComponentContentByComponentContentId(int componentContentId)
        {
            var result = _componentContentService.GetOneComponentContentByComponentContentId(componentContentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetComponentContentsByComponentId")]
        public IActionResult GetComponentContentsByComponentId(int componentId)
        {
            var result = _componentContentService.GetComponentContentsByComponentId(componentId);
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
        public IActionResult Add(ComponentContent componentContent)
        {
            var result = _componentContentService.Add(componentContent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(ComponentContent componentContent)
        {
            var result = _componentContentService.Update(componentContent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(ComponentContent componentContent)
        {
            var result = _componentContentService.Delete(componentContent);
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
