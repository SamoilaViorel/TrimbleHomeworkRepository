import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StringExerciseComponent } from './string-exercise.component';

describe('StringExerciseComponent', () => {
  let component: StringExerciseComponent;
  let fixture: ComponentFixture<StringExerciseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StringExerciseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StringExerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
