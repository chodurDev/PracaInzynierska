import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MyFirstAidKitComponent } from './myFirstAidKit/myFirstAidKit.component';
import { AuthGuard } from './_guards/auth.guard';
import { CurrentlyUsedComponent } from './currentlyUsed/currentlyUsed.component';
import { ShortTermMedicinesComponent } from './shortTermMedicines/shortTermMedicines.component';
import { MedicineDatabaseComponent } from './medicineDatabase/medicineDatabase.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'myFirstAidKit', component: MyFirstAidKitComponent },
      { path: 'currentlyUsed', component: CurrentlyUsedComponent },
      { path: 'shortTermMedicines', component: ShortTermMedicinesComponent },
      { path: 'medicineDatabase', component: MedicineDatabaseComponent },
    ]
  },

  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
