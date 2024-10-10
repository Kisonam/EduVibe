import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBarMainComponent } from './nav-bar-main/nav-bar-main.component'; 
import { LogInPageComponent } from './pages/log-in-page/log-in-page.component';
import { MainPageComponent } from './pages/main-page/main-page/main-page.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavBarMainComponent, MainPageComponent, LogInPageComponent, ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'client';
}
