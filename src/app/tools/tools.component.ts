import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  title: string = "Something";
  textColor: string = "white";
  noteContent:string="";

  constructor() { }

  ngOnInit(): void {
  }

  buttonClick(): void {
    this.title = "Something else";
    this.textColor=this.noteContent;
  }

}
