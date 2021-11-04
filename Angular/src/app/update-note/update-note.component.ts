import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../models/category';
import { FilterService } from '../services/filter.service';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-update-note',
  templateUrl: './update-note.component.html',
  styleUrls: ['./update-note.component.scss']
})
export class UpdateNoteComponent implements OnInit {
  title: string = "";
  description: string = "";
  categoryId:string="";
  categories:Category[];
  id:string="";

  constructor(private router:Router, private _activatedRoute: ActivatedRoute, private filterService:FilterService, private noteService:NoteService) { }

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe(params => {
      this.title = params["title"];
      this.description = params["description"];
      this.id=params["id"];
    })
    this.categories=this.filterService.getFilters();
  }

  add(){
    this.noteService.updateNote(this.id, this.title,this.description,this.categoryId).subscribe(()=>this.router.navigateByUrl(''));
  }
}
