import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../auth.service';
import { NavBarMainComponent } from '../../nav-bar-main/nav-bar-main.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-log-in-page',
  standalone: true,
  imports: [CommonModule, NavBarMainComponent, FormsModule],
  templateUrl: './log-in-page.component.html',
  styleUrls: ['./log-in-page.component.scss'],
})
export class LogInPageComponent {
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.username, this.password).subscribe(
      (response) => {
        console.log('Login successful', response);
        // Отобразить сообщение об успешном входе
        alert(`Пользователь ${this.username} успешно вошел в систему`);
        this.router.navigate(['/profile-redact']); // Перенаправление на страницу редактирования профиля
      },
      (error) => {
        console.error('Login failed', error);
        // Отобразить сообщение об ошибке
        alert('Ошибка входа: Неверный логин или пароль');
      }
    );
  }
}
