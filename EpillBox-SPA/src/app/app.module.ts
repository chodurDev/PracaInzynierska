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
import { TableForFAKMedicineComponent } from './tableForFAKMedicine/tableForFAKMedicine.component';
import { ShortTermMedicinesComponent } from './shortTermMedicines/shortTermMedicines.component';
import { TableForMedicineComponent } from './tableForMedicine/tableForMedicine.component';
import { DialogAddUserFAKComponent } from './dialogs/dialogAddUserFAK/dialogAddUserFAK.component';
import { DialogDeleteUserFAKComponent } from './dialogs/dialogDeleteUserFAK/dialogDeleteUserFAK.component';

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
    DialogDeleteUserFAKComponent
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
    SidebarModule.forRoot()
  ],
  exports: [AngularMaterialsModule],
  entryComponents: [DialogAddUserFAKComponent, DialogDeleteUserFAKComponent],
  providers: [ErrorInterceptorProvider, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule {}
