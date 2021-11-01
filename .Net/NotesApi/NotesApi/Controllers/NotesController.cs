using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using NotesApi.Services;
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


        INoteCollectionService _noteCollectionService;

        public NotesController(INoteCollectionService noteCollectionService)
        {
            _noteCollectionService = noteCollectionService;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            List<Notes> notes = _noteCollectionService.GetAll();
            return Ok(notes);
        }


        [HttpGet("ownerId/{ownerId}")]
        public IActionResult GetByOwnerId(Guid ownerId)
        {
            return Ok(_noteCollectionService.GetNotesByOwnerId(ownerId));
        }

        [HttpGet("{id}", Name = "GetNoteByIdName")]
        public IActionResult GetNoteById(Guid id)
        {
            var note = _noteCollectionService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] Notes note)
        {
            if (note == null)
            {
                return BadRequest("Note cannot be null");
            }

            if (_noteCollectionService.Create(note))
            {
                return CreatedAtRoute("GetNoteByIdName", new { id = note.Id.ToString() }, note);
            }

            return NoContent();
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateNote(Guid id, Guid ownerId, [FromBody] Notes noteToUpdate)
        //{
        //    if (noteToUpdate == null)
        //    {
        //        return BadRequest("Note cannot be null");
        //    }

        //    int index;

        //    if (ownerId != null)
        //    {
        //        index = _notes.FindIndex(note => note.Id == id && note.OwnerId == ownerId);

        //    }
        //    else
        //    {
        //        index = _notes.FindIndex(note => note.Id == id);

        //    }
        //    if (index == -1)
        //    {
        //        return NotFound();
        //    }
        //    noteToUpdate.Id = _notes[index].Id;
        //    _notes[index] = noteToUpdate;
        //    return Ok(_notes[index]);
        //}


        [HttpPut("{id}")]
        public IActionResult UpdateNote(Guid id, [FromBody] Notes noteToUpdate)
        {
            if (noteToUpdate == null)
            {
                return BadRequest("Note cannot be null");
            }
            if (!_noteCollectionService.Update(id, noteToUpdate))
            {
                return NotFound();
            }

            return NoContent();

        }


        //[HttpDelete("{id}")]
        //public IActionResult DeleteNote(Guid id, Guid ownerId)
        //{
        //    int index;

        //    if (ownerId != null)
        //    {
        //        index = _notes.FindIndex(note => note.Id == id && note.OwnerId == ownerId);
        //    }
        //    else
        //    {
        //        index = _notes.FindIndex(note => note.Id == id);
        //    }

        //    if (index == -1)
        //    {
        //        return NotFound();
        //    }

        //    _notes.RemoveAt(index);

        //    return NoContent();

        //}


        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            if(!_noteCollectionService.Delete(id))
            {
                return NotFound();
            }

            return NoContent();

        }

        //[HttpDelete("ownerId/{ownerId}")]
        //public IActionResult DeleteAllNotesGivenByOwnerId(Guid ownerId)
        //{
        //    _notes.RemoveAll(note => note.OwnerId == ownerId);

        //    return NoContent();
        //}


        //[HttpPatch("{id}/title")]
        //public IActionResult UpdateTitleNote(Guid id, [FromBody] string title)
        //{
        //    if (string.IsNullOrEmpty(title))
        //    {
        //        return BadRequest("The string cannot be null");
        //    }

        //    int index = _notes.FindIndex(note => note.Id == id);
        //    if (index == -1)
        //    {
        //        return NotFound();
        //    }

        //    _notes[index].Title = title;

        //    return NoContent();

        //}

        ///// <summary>
        /////   Returns a list of notes
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("test")]
        //public IActionResult Get()
        //{
        //    return Ok("Note controller works");
        //}
    }
}
