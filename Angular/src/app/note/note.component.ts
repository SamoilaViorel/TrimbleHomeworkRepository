import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NoteService } from '../services/note.service';
import { Note } from './note';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit, OnChanges {

  notes: Note[];
  @Input() selectedCategoryId: string;
  @Input() selectedTitle: string;


  constructor(private router: Router, private noteService: NoteService) { }


  ngOnInit(): void {
    this.noteService.serviceCall();
    this.getNotes();
  }


  ngOnChanges(): void {

    console.log("da");
    // this.notes = this.noteService.getSearchedNotes(this.selectedTitle, this.selectedCategoryId);
    this.noteService.getFiltredNotes(this.selectedCategoryId).subscribe((result) => {
      this.notes = result;
    });
    // this.notes = this.noteService.getSearchedNotes(this.selectedTitle);
    // this.notes = this.noteService.getFiltredNotes(this.selectedCategoryId);

  }

  showNote(note: any): void {
    this.router.navigate(['/addNote'], { queryParams: { title: note.title, description: note.description } });
  }

  deleteNote(id: string) {
    this.noteService.deleteNote(id).subscribe(() => {
      this.getNotes();
    });


  }

  getNotes() {
    this.noteService.getNotes().subscribe((result) => {
      this.notes = result;
    });
  }

}
