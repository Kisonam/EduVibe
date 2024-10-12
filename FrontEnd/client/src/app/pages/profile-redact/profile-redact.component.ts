import { Component } from '@angular/core';
import { NavBarMainComponent } from '../../nav-bar-main/nav-bar-main.component';
import { ImageCropperComponent } from 'ngx-image-cropper'; // Импортируем компонент для обрезки изображений
import { CommonModule } from '@angular/common'; // Для использования *ngIf и других директив
import { log } from '@angular-devkit/build-angular/src/builders/ssr-dev-server';

@Component({
  selector: 'app-profile-redact',
  standalone: true,
  imports: [NavBarMainComponent, CommonModule, ImageCropperComponent], // Добавляем необходимые компоненты
  templateUrl: './profile-redact.component.html',
  styleUrls: ['./profile-redact.component.scss']
})
export class ProfileRedactComponent {
  imageChangedEvent: any = '';  // Хранит событие изменения изображения
  croppedImage: any = '';       // Хранит обрезанное изображение (base64)

  // Обработка загрузки нового изображения
  onFileChange(event: any): void {
    this.imageChangedEvent = event;  // Сохраняем событие изменения
  }

  saveCroppedImage() {
  if (this.croppedImage) {
    // Действие по сохранению изображения
    console.log('Cropped Image Saved:', this.croppedImage);
  }
}


  // Обработка обрезки изображения
  imageCropped(event: any) {
    this.croppedImage = event.base64;  // Сохраняем обрезанное изображение в формате base64
  }

  // Сброс изображения
  resetImage() {
    this.croppedImage = '';       // Очищаем обрезанное изображение
    this.imageChangedEvent = '';  // Сбрасываем событие изменения изображения
  }
}
