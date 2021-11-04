import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Note } from '../note/note';
import { map } from "rxjs/operators";

@Injectable()
export class NoteService {

  
  readonly baseUrl= "http://localhost:5000";
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };


  constructor(private httpClient: HttpClient) { }

  serviceCall() {
    console.log("Note service was called");
  }


  getNotes():Observable<Note[]>{
    return this.httpClient.get<Note[]>(this.baseUrl+'/notes',this.httpOptions);
  }

  addNote(noteTitle:string, noteDescription:string, noteCategoryId:string):Observable<Note>{
    let note= {  
                description: noteDescription,
                title: noteTitle,
                categoryId: noteCategoryId
                }
  return  this.httpClient.post<Note>(this.baseUrl+"/notes", note, this.httpOptions);
}


deleteNote(id:string){
  return this.httpClient.delete(this.baseUrl+'/notes/'+id);
}


  getFiltredNotes(categoryId:string):Observable<Note[]>{
    console.log("ceva");
    return this.httpClient
    .get<Note[]>(this.baseUrl+'/notes',this.httpOptions)
    .pipe( map((notes) => notes.filter((note) => note.categoryId === categoryId)));
  }



  // getNotes(): Note[] {
  //   return [...this.notes];
  // }

  // updateNotes(note: Note) {
  //   this.notes.push(note);
  // }




  // getFiltredNotes(categoryId: string, title: string): Note[] {
  //   console.log("ceva");
  //   let notes = this.notes;
  //   if (title) {
  //     notes = notes.filter(note => note.title === title);
  //   }
  //   if (categoryId) {
  //     notes = notes.filter(note => note.categoryId === categoryId);
  //   }

  //   return notes;
  // }



 
}
