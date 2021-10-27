import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DummyParamComponent } from './dummy-param.component';

describe('DummyParamComponent', () => {
  let component: DummyParamComponent;
  let fixture: ComponentFixture<DummyParamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DummyParamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DummyParamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
