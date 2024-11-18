import { Routes } from '@angular/router';
import { LogInPageComponent } from './pages/log-in-page/log-in-page.component';
import { SignInPageComponent } from './pages/sing-in-page/sing-in-page.component';
import { ProfileRedactComponent } from './pages/profile-redact/profile-redact.component';
import { MainPageComponent } from './pages/main-page/main-page/main-page.component';
import { ProfilePublicViewComponent } from './pages/profile-public-view/profile-public-view.component';


export const routes: Routes = [
  { path: '', component: MainPageComponent, data: { title: 'Main page' } },
  { path: 'log-in', component: LogInPageComponent, data: { title: 'Log in' } },
  { path: 'sign-up', component: SignInPageComponent, data: { title: 'Sign up' } },
  { path: 'profile-redact', component: ProfileRedactComponent, data: { title: 'Profile redact' } },
  {path: 'profile-public-view', component: ProfilePublicViewComponent, data: { title: 'Profile public view'} }, 
  { path: '**', redirectTo: '' }, // Перенаправление на главную страницу, если маршрут не найден
];
