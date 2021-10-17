import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Test1Module } from './test1/test1.module';
import { NoteComponent } from './note/note.component';
import { ToolsComponent } from './tools/tools.component';
import {MatButtonModule } from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { StringExerciseComponent } from './string-exercise/string-exercise.component';
import { AddHyphenPipe } from './add-hyphen.pipe';
import { ColorChangeDirective } from './color-change.directive';
@NgModule({
  declarations: [
    AppComponent,
    NoteComponent,
    ToolsComponent,
    StringExerciseComponent,
    AddHyphenPipe,
    ColorChangeDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    Test1Module,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
