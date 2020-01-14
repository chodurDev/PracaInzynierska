/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TableMedicineToBuyComponent } from './tableMedicineToBuy.component';

describe('TableMedicineToBuyComponent', () => {
  let component: TableMedicineToBuyComponent;
  let fixture: ComponentFixture<TableMedicineToBuyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMedicineToBuyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMedicineToBuyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
