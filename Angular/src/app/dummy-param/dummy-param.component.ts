import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-dummy-param',
  templateUrl: './dummy-param.component.html',
  styleUrls: ['./dummy-param.component.scss']
})
export class DummyParamComponent implements OnInit {

  id: number;

  constructor(private _activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this._activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.id = +params.get('id');
    });
    // this._activatedRoute.params.subscribe(params=>{
    //   this.id=params['id'];
    // })
  }

}
