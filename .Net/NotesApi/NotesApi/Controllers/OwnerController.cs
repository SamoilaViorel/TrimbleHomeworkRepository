using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using NotesApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ownerService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Owner owner)
        {
            if(owner==null)
            {
                return BadRequest("Owner cannot be null");
            }
            if(_ownerService.Create(owner))
            {
                return Ok();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            if (!_ownerService.Delete(id))
            {
                return NotFound();
            }

            return NoContent();

        }


        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner ownerToUpdate)
        {
            if (ownerToUpdate == null)
            {
                return BadRequest("Owner cannot be null");
            }

           if(!_ownerService.Update(id,ownerToUpdate))
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
