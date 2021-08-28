import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CounterngrxOutputComponent } from './counterngrx-output.component';

describe('CounterngrxOutputComponent', () => {
  let component: CounterngrxOutputComponent;
  let fixture: ComponentFixture<CounterngrxOutputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CounterngrxOutputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CounterngrxOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
