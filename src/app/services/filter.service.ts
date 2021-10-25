import { Injectable } from '@angular/core';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  categories: Category[] = [
    {
      id: '1',
      name: 'To Do'
    },
    {
      id: '2',
      name: 'Done'
    },
    {
      id: '3',
      name: 'Doing'
    }
  ]

  getFilters(){
    return this.categories;
  }

  constructor() { }
}
