import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-string-exercise',
  templateUrl: './string-exercise.component.html',
  styleUrls: ['./string-exercise.component.scss']
})
export class StringExerciseComponent implements OnInit {

stringList:string[]=["apa","aer","mancare", "legume"];
dateList:Date[]=[new Date(2020,3,15),new Date(2021,4,15),new Date(2021,5,15)];



  constructor() { }

  ngOnInit(): void {
  }

}
