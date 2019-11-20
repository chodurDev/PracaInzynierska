import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

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
import {NgxPaginationModule} from 'ngx-pagination';
import { AngularMaterialsModule } from './angular-materials.module';
import {FlexLayoutModule} from '@angular/flex-layout';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      MyFirstAidKitComponent,
      SideBarContentComponent,
      CurrentlyUsedComponent
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
      NgxPaginationModule
      
   ],
   exports:[AngularMaterialsModule],

   providers: [
      ErrorInterceptorProvider,
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
