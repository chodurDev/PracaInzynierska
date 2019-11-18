/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MyFirstAidKitComponent } from './myFirstAidKit.component';

describe('MyFirstAidKitComponent', () => {
  let component: MyFirstAidKitComponent;
  let fixture: ComponentFixture<MyFirstAidKitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyFirstAidKitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyFirstAidKitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
