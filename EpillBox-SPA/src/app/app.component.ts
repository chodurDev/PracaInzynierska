import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import * as signalR from '@microsoft/signalr';
import { AlertifyService } from './_services/alertify.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  closeOnClickOutside = true;
  opened = false;
  mode: string = 'push';

  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      this.router.navigate(['/myFirstAidKit']);
    }

    const connection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5000/hub')
      .build();

    connection.on('messageReceived', (message: string) => {
      this.alertify.confirm(message, () => {});
    });

    connection.start().catch(err => console.log(err));
  }

  onToggleSideBar(value: boolean) {
    this.opened = value;
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
