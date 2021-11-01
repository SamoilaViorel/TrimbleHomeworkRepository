using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
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
        List<Owner> _ownerList = new List<Owner>()
        {
            new Owner(){ Id = new Guid("00000000-0000-0000-0000-000000000001"), Name="Ana"},
            new Owner(){ Id = new Guid("00000000-0000-0000-0000-000000000002"), Name="Emil"},
            new Owner(){ Id = new Guid("00000000-0000-0000-0000-000000000003"), Name="Ion"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ownerList);
        }

        [HttpPost]
        public IActionResult Post(Owner owner)
        {
            _ownerList.Add(owner);
            return Ok(_ownerList);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            int index = _ownerList.FindIndex(owner => owner.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            _ownerList.RemoveAt(index);

            return NoContent();

        }


        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner ownerToUpdate)
        {
            if (ownerToUpdate == null)
            {
                return BadRequest("Owner cannot be null");
            }

            int index = _ownerList.FindIndex(note => note.Id == id);

            if (index == -1)
            {
                return NotFound();
            }
            ownerToUpdate.Id = _ownerList[index].Id;
            _ownerList[index] = ownerToUpdate;
            return Ok(_ownerList[index]);
        }


    }
}
