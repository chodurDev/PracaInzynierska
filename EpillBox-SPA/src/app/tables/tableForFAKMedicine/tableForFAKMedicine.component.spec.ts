/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TableForFAKMedicineComponent } from './tableForFAKMedicine.component';

describe('TableForFAKMedicineComponent', () => {
  let component: TableForFAKMedicineComponent;
  let fixture: ComponentFixture<TableForFAKMedicineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableForFAKMedicineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableForFAKMedicineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
