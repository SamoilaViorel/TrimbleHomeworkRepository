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
    public class CategoriesController : ControllerBase
    {

        List<Category> categories = new List<Category>() {
        new Category(){Id="1",Name="To do"},
        new Category(){Id="1",Name="Done"},
        new Category(){Id="3",Name="Doing"}
        };

        /// <summary>
        /// returns elements from our list("categories")
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categories);
        }


        /// <summary>
        /// returns the element from our list("categories") according to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(categories.Where(c=>c.Id==id));
        }

        /// <summary>
        /// returns the list with her new element added
        /// </summary>
        /// <param name="bodyContent"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Category bodyContent)
        {
            categories.Add(bodyContent);
            return Ok(categories);
        }

        /// <summary>
        /// returns the list after we made a delete based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var itemToRemove = categories.Where(c => c.Id == id).First();
            categories.Remove(itemToRemove);
            return Ok(categories);
        }

    }
}
