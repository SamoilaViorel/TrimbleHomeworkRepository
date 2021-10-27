import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Comp3Component } from './comp3/comp3.component';



@NgModule({
  declarations: [
    Comp3Component
  ],
  imports: [
    CommonModule
  ],
  exports:[
    Comp3Component
  ]
})
export class Test3Module { }
