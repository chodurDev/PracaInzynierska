/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DialogAddMedicineToFAKComponent } from './dialogAddMedicineToFAK.component';

describe('DialogAddMedicineToFAKComponent', () => {
  let component: DialogAddMedicineToFAKComponent;
  let fixture: ComponentFixture<DialogAddMedicineToFAKComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogAddMedicineToFAKComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogAddMedicineToFAKComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
