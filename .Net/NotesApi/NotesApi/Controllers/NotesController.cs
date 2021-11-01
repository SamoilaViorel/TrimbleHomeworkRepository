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

        private static List<Notes> _notes = new List<Notes> { new Notes { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        new Notes { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        new Notes { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        new Notes { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Notes { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000002"), Title = "Fifth Note", Description = "Fifth Note Description" }
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

        [HttpPut("{id}")]
        public IActionResult UpdateNote(Guid id, Guid ownerId, [FromBody] Notes noteToUpdate)
        {
            if (noteToUpdate == null)
            {
                return BadRequest("Note cannot be null");
            }

            int index;

            if (ownerId != null)
            {
                index = _notes.FindIndex(note => note.Id == id && note.OwnerId == ownerId);

            }
            else
            {
                index = _notes.FindIndex(note => note.Id == id);

            }
            if (index == -1)
            {
                return NotFound();
            }
            noteToUpdate.Id = _notes[index].Id;
            _notes[index] = noteToUpdate;
            return Ok(_notes[index]);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id, Guid ownerId)
        {
            int index;

            if (ownerId != null)
            {
                index = _notes.FindIndex(note => note.Id == id && note.OwnerId == ownerId);
            }
            else
            {
                index = _notes.FindIndex(note => note.Id == id);
            }

            if (index == -1)
            {
                return NotFound();
            }

            _notes.RemoveAt(index);

            return NoContent();

        }

        [HttpDelete("ownerId/{ownerId}")]
        public IActionResult DeleteAllNotesGivenByOwnerId(Guid ownerId)
        {
            _notes.RemoveAll(note => note.OwnerId == ownerId);

            return NoContent();
        }


        [HttpPatch("{id}/title")]
        public IActionResult UpdateTitleNote(Guid id, [FromBody] string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("The string cannot be null");
            }

            int index = _notes.FindIndex(note => note.Id == id);
            if (index == -1)
            {
                return NotFound();
            }

            _notes[index].Title = title;

            return NoContent();

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
