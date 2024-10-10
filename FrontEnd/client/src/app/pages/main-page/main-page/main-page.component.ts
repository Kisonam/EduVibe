import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { LogInPageComponent } from "../../log-in-page/log-in-page.component";
import { NavBarMainComponent } from "../../../nav-bar-main/nav-bar-main.component";




@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, LogInPageComponent, NavBarMainComponent],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.scss'
})
export class MainPageComponent {
  title = 'client';

  constructor(private router: Router) {}
  
  navigateToSignUp() {
    console.log('Navigating to Sign up');  // Лог для проверки
    this.router.navigate(['/sign-up']);
  }
}
