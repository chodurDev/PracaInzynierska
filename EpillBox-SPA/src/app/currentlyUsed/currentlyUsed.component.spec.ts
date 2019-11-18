/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CurrentlyUsedComponent } from './currentlyUsed.component';

describe('CurrentlyUsedComponent', () => {
  let component: CurrentlyUsedComponent;
  let fixture: ComponentFixture<CurrentlyUsedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrentlyUsedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentlyUsedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
