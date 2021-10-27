using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {

        static List<Notes> _notes = new List<Notes> { new Notes { Id = new System.Guid(), CategoryId = "1", OwnerId = new System.Guid(), Title = "First Note", Description = "First Note Description" },
        new Notes { Id = new System.Guid("8d1f5da0-e680-4e3d-b065-6ad5ce0d1f23"), CategoryId = "1", OwnerId = new System.Guid(), Title = "Second Note", Description = "Second Note Description" },
        new Notes { Id = new System.Guid("8d1f5da0-e680-4e3d-b065-6ad5ce0d1f23"), CategoryId = "1", OwnerId = new System.Guid(), Title = "Third Note", Description = "Third Note Description" },
        new Notes { Id = new System.Guid(), CategoryId = "1", OwnerId = new System.Guid(), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Notes { Id = new System.Guid(), CategoryId = "1", OwnerId = new System.Guid(), Title = "Fifth Note", Description = "Fifth Note Description" }
        };


        public NotesController()
        {

        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notes);
        }


        [HttpGet("ownerId/{ownerId}")]
        public IActionResult GetByOwnerId(Guid ownerId)
        {
            List<Notes> note = _notes.FindAll(note => note.OwnerId == ownerId);
            return Ok(note);
        }

        [HttpGet("{id}", Name = "GetNoteById")]
        public IActionResult GetNoteById(Guid id)
        {
            return Ok(_notes.Where(c => c.Id == id));
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] Notes note)
        {
            if (note == null)
            {
                return BadRequest("Note cannot be null");
            }
            _notes.Add(note);
            return CreatedAtRoute("GetNoteById", new { id = note.Id.ToString() }, note);
        }

        /// <summary>
        ///   Returns a list of notes
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public IActionResult Get()
        {
            return Ok("Note controller works");
        }
    }
}
