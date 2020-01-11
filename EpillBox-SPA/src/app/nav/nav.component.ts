import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  @Output() toggleSideBar = new EventEmitter();
  routeName: string;
  constructor(
    public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {
    router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        this.changeNavTitle();
      });
  }

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged in succesfully');
      },
      error => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['/myFirstAidKit']);
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('chosenFAK');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }
  showSideBar() {
    this.toggleSideBar.emit(true);
  }

  changeNavTitle() {
    switch (this.router.url) {
      case '/myFirstAidKit':
        this.routeName = 'Moje Apteczki';
        break;
      case '/currentlyUsed':
        this.routeName = 'Aktualnie zażywane lekarstwa';
        break;
      case '/shortTermMedicines':
        this.routeName = 'Lekarstwa z krótką datą przydatności';
        break;
      case '/medicineDatabase':
        this.routeName = 'Baza lekarstw';
        break;
      case '/medicineToBuy':
        this.routeName = 'Lekarstwa do zamówienia';
        break;
      case '/editUser':
        this.routeName = 'Profil użytkownika';
        break;
      case '/allergies':
        this.routeName = 'Uczulające substancje aktywne';
        break;
      default:
        this.routeName = '';
        break;
    }
  }
}
