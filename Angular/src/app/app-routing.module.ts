import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNoteComponent } from './add-note/add-note.component';
import { DummyParamComponent } from './dummy-param/dummy-param.component';
import { HomeComponent } from './home/home.component';

const appRoutes: Routes = [
  { path: "", component: HomeComponent, pathMatch: 'full' },
  { path: "addNote", component: AddNoteComponent },
  { path: "dummyParam/:id", component: DummyParamComponent },
  { path: '**', redirectTo: 'addNote' }
]

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
