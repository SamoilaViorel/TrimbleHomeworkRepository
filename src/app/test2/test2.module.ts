import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Test3Module } from '../test3/test3.module';
import { Comp2Component } from './comp2/comp2.component';
import { Comp3Component } from '../test3/comp3/comp3.component';



@NgModule({
  declarations: [
    Comp2Component
  ],
  imports: [
    CommonModule,
    Test3Module
  ],
  exports:[
    Comp2Component,
    Comp3Component
  ]
})
export class Test2Module { }
