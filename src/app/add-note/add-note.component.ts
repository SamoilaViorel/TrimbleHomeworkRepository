import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../models/category';
import { Note } from '../note/note';
import { FilterService } from '../services/filter.service';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  
  title: string = "";
  description: string = "";
  categories:Category[];

  constructor(private _activatedRoute: ActivatedRoute, private noteService: NoteService, private filterService:FilterService) { }

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe(params => {
      this.title = params["title"];
      this.description = params["description"];
    })
    this.categories=this.filterService.getFilters();
  }

  save() {
    const note: Note={id:"", title:"", description:"", categoryId:""};
    note.title = this.title;
    note.description = this.description;
    this.noteService.updateNotes(note);
  }

}
