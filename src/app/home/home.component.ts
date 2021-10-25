import { Component, OnInit } from '@angular/core';
import { Note } from '../note/note';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  notes:Note[];
  categoryId: string

  constructor() { }

  ngOnInit(): void {
  }

  // takeNotes(notes:Note[]) {
  //  this.notes=notes;
  // }

  receivedCategory(categoryId: string) {
    this.categoryId = categoryId;
  }

}
