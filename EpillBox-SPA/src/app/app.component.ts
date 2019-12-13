import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  closeOnClickOutside = true;
  opened = false;
  mode: string = 'slide';

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      this.router.navigate(['/myFirstAidKit']);
    }
  }

  onToggleSideBar(value: boolean) {
    this.opened = value;
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
