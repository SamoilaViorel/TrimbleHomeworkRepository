import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Test2Module } from '../test2/test2.module';
import { Comp1Component } from './comp1/comp1.component';
import { Comp2Component } from '../test2/comp2/comp2.component';
import { Comp3Component } from '../test3/comp3/comp3.component';



@NgModule({
  declarations: [
    Comp1Component
    ],
  imports: [
    CommonModule,
    Test2Module
  ],
  exports:[
    Comp1Component,
    Comp3Component
  ]
})
export class Test1Module { }
