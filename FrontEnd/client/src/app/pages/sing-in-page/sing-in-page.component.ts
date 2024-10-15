import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../auth.service';
import { NavBarMainComponent } from '../../nav-bar-main/nav-bar-main.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-sign-in-page',
  standalone: true,
  imports: [CommonModule, NavBarMainComponent, FormsModule],
  templateUrl: './sing-in-page.component.html',
  styleUrls: ['./sing-in-page.component.scss'],
})
export class SignInPageComponent {
  username: string = '';
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  register() {
    this.authService.register(this.username, this.password, this.email).subscribe(
      (response) => {
        console.log('Registration successful', response);
        // Отобразить сообщение об успешной регистрации
        alert(`Пользователь ${this.username} успешно зарегистрирован`);
        this.router.navigate(['/log-in']); // Перенаправление на страницу логина
      },
      (error) => {
        console.error('Registration failed', error);
        // Отобразить сообщение об ошибке
        alert('Ошибка регистрации: ' + error.error);
      }
    );
  }
}
