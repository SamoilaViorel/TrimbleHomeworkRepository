import { Injectable } from '@angular/core';
import { Note } from '../note/note';

@Injectable()
export class NoteService {

  notes: Note[] = [
    {
      id: "Id1",
      title: "First note",
      description: "This is the description for the first note",
      categoryId:"1"
    },
    {
      id: "Id2",
      title: "Second note",
      description: "This is the description for the second note",
      categoryId:"2"

    },
    {
      id: "Id3",
      title: "Third note",
      description: "This is the description for the third note",
      categoryId:"3"

    }
  ];

  constructor() { }

  serviceCall() {
    console.log("Note service was called");
  }

  
  getNotes(): Note[] {
    return [...this.notes];
  }

  updateNotes(note:Note){
     this.notes.push(note);
  }


  getFiltredNotes(categoryId:string):Note[]{
    console.log("ceva");
    return this.notes.filter(note=>note.categoryId === categoryId);
  }
}
