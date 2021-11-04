import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  categoryId:string="";
  categories:Category[];

  constructor(private router:Router, private _activatedRoute: ActivatedRoute, private filterService:FilterService, private noteService:NoteService) { }

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe(params => {
      this.title = params["title"];
      this.description = params["description"];
    })
    this.categories=this.filterService.getFilters();
  }

  add(){
    this.noteService.addNote(this.title,this.description,this.categoryId).subscribe(()=>this.router.navigateByUrl(''));
  }
  // save() {
  //   const note: Note={id:"", title:"", description:"", categoryId:""};
  //   note.title = this.title;
  //   note.description = this.description;
  //   note.categoryId=this.categoryId;
  //   this.noteService.updateNotes(note);
  // }

}
