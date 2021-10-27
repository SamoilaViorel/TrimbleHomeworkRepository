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
            new Owner(){ Id = new System.Guid(), Name="Ana"},
            new Owner(){ Id = new System.Guid(), Name="Emil"},
            new Owner(){ Id = new System.Guid(), Name="Ion"}
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



    }
}
