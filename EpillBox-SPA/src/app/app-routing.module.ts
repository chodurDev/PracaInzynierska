import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MyFirstAidKitComponent } from './myFirstAidKit/myFirstAidKit.component';
import { AuthGuard } from './_guards/auth.guard';
import { CurrentlyUsedComponent } from './currentlyUsed/currentlyUsed.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'myFirstAidKit', component: MyFirstAidKitComponent },
      { path: 'currentlyUsed', component: CurrentlyUsedComponent }
    ]
  },

  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
