/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TableCurrentlyUsedComponent } from './tableCurrentlyUsed.component';

describe('TableCurrentlyUsedComponent', () => {
  let component: TableCurrentlyUsedComponent;
  let fixture: ComponentFixture<TableCurrentlyUsedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableCurrentlyUsedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableCurrentlyUsedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
