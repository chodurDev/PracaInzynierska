import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap';
import { SidebarModule } from 'ng-sidebar';
import { MyFirstAidKitComponent } from './myFirstAidKit/myFirstAidKit.component';
import { SideBarContentComponent } from './sideBarContent/sideBarContent.component';
import { CurrentlyUsedComponent } from './currentlyUsed/currentlyUsed.component';
import { AngularMaterialsModule } from './angular-materials.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { TableForFAKMedicineComponent } from './tables/tableForFAKMedicine/tableForFAKMedicine.component';
import { ShortTermMedicinesComponent } from './shortTermMedicines/shortTermMedicines.component';
import { TableForMedicineComponent } from './tables/tableForMedicine/tableForMedicine.component';
import { DialogAddUserFAKComponent } from './dialogs/dialogAddUserFAK/dialogAddUserFAK.component';
import { DialogDeleteUserFAKComponent } from './dialogs/dialogDeleteUserFAK/dialogDeleteUserFAK.component';
import { DialogAddMedicineToFAKComponent } from './dialogs/dialogAddMedicineToFAK/dialogAddMedicineToFAK.component';
import { TableCurrentlyUsedComponent } from './tables/tableCurrentlyUsed/tableCurrentlyUsed.component';
import { MedicineDatabaseComponent } from './medicineDatabase/medicineDatabase.component';
import { TableMedicineDatabaseComponent } from './tables/tableMedicineDatabase/tableMedicineDatabase.component';
import {NgxPopperModule} from 'ngx-popper';
import { MedicineToBuyComponent } from './medicineToBuy/medicineToBuy.component';
import { EditUserComponent } from './editUser/editUser.component';
import { DialogAddAllergyComponent } from './dialogs/dialogAddAllergy/dialogAddAllergy.component';
import { DialogAddMedicineToDatabaseComponent } from './dialogs/dialogAddMedicineToDatabase/dialogAddMedicineToDatabase.component';
import { DialogSetScheduleComponent } from './dialogs/dialogSetSchedule/dialogSetSchedule.component';

import {NgxMaterialTimepickerModule} from 'ngx-material-timepicker';
import { TableMedicineToBuyComponent } from './tables/tableMedicineToBuy/tableMedicineToBuy.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      MyFirstAidKitComponent,
      SideBarContentComponent,
      CurrentlyUsedComponent,
      TableForFAKMedicineComponent,
      ShortTermMedicinesComponent,
      TableForMedicineComponent,
      DialogAddUserFAKComponent,
      DialogDeleteUserFAKComponent,
      DialogAddMedicineToFAKComponent,
      TableCurrentlyUsedComponent,
      MedicineDatabaseComponent,
      TableMedicineDatabaseComponent,
      MedicineToBuyComponent,
      EditUserComponent,
      DialogAddAllergyComponent,
      DialogAddMedicineToDatabaseComponent,
      DialogSetScheduleComponent,
      TableMedicineToBuyComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      AngularMaterialsModule,
      FlexLayoutModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      BsDropdownModule.forRoot(),
      SidebarModule.forRoot(),
      NgxPopperModule.forRoot(),
      NgxMaterialTimepickerModule
   ],
   exports: [
      AngularMaterialsModule
   ],
   entryComponents: [
      DialogAddUserFAKComponent,
      DialogDeleteUserFAKComponent,
      DialogAddMedicineToFAKComponent,
      DialogAddAllergyComponent,
      DialogAddMedicineToDatabaseComponent,
      DialogSetScheduleComponent
   ],
   providers: [
      ErrorInterceptorProvider,
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {}
