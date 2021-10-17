import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'addHyphen'
})
export class AddHyphenPipe implements PipeTransform {

  transform(value: string, addedValue:string): string {
    return (addedValue.concat(value)).concat(addedValue);
  }

}
