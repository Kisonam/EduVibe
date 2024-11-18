import { Component } from '@angular/core';
import { NavBarMainComponent } from "../../nav-bar-main/nav-bar-main.component";

@Component({
  selector: 'app-profile-public-view',
  standalone: true,
  imports: [NavBarMainComponent],
  templateUrl: './profile-public-view.component.html',
  styleUrl: './profile-public-view.component.scss'
})
export class ProfilePublicViewComponent {

}
