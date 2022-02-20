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
    public class ComponentsController : ControllerBase
    {
        /* Dependency Injection */
        #region Dependency Injection
        IComponentService _componentService;

        public ComponentsController(IComponentService componentService)
        {
            _componentService = componentService;
        }
        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _componentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetOneComponentByComponentId")]
        public IActionResult GetOneComponentByComponentId(int componentId)
        {
            var result = _componentService.GetOneComponentByComponentId(componentId);
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
        [HttpGet("GetAllComponentDetails")]
        public IActionResult GetAllComponentDetails()
        {
            var result = _componentService.GetAllComponentDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllComponentDetailsByComponentId")]
        public IActionResult GetAllComponentDetailsByComponentId(int componentId)
        {
            var result = _componentService.GetAllComponentDetailsByComponentId(componentId);
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
        public IActionResult Add(Component component)
        {
            var result = _componentService.Add(component);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Component component)
        {
            var result = _componentService.Update(component);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Component component)
        {
            var result = _componentService.Delete(component);
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
