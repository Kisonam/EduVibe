import { log } from '@angular-devkit/build-angular/src/builders/ssr-dev-server';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-nav-bar-main',
  templateUrl: './nav-bar-main.component.html',
  styleUrls: ['./nav-bar-main.component.scss']
})
export class NavBarMainComponent {
  logoPath = 'assets/Compass.png';

  constructor(private router: Router) {}  // Внедряем Router через конструктор

  // Метод для перехода на страницу логина
  navigateToLogin() {
    console.log('Navigating to Log in');  // Лог для проверки
    this.router.navigate(['/log-in']);
  }

  // Метод для перехода на страницу регистрации
  navigateToSignUp() {
    console.log('Navigating to Sign up');  // Лог для проверки
    this.router.navigate(['/sign-up']);
  }
}

