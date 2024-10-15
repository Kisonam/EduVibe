//import { log } from '@angular-devkit/build-angular/src/builders/ssr-dev-server';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-nav-bar-main',
  templateUrl: './nav-bar-main.component.html',
  styleUrls: ['./nav-bar-main.component.scss'],
})
export class NavBarMainComponent {
  logoPath = 'assets/Compass.png';

  constructor(private router: Router) {}

  navigateToLogin() {
    console.log('Navigating to Log in');
    this.router.navigate(['/log-in']);
  }

  navigateToSignUp() {
    console.log('Navigating to Sign up');
    this.router.navigate(['/sign-up']);
  }
}
