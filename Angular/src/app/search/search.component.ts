import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Note } from '../note/note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  @Output() emitSelectedTitle=new EventEmitter<string>();

  constructor(private noteService:NoteService) { }

  ngOnInit(): void {
  }

  // save() {
  //   const note: Note={id:"", title:"", description:"", categoryId:""};
  //   note.title = this.title;
   
  //   this.noteService.updateNotes(note);
  // }

  selectTitle(title:string){
    this.emitSelectedTitle.emit(title);
  }

}
