import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilePublicViewComponent } from './profile-public-view.component';

describe('ProfilePublicViewComponent', () => {
  let component: ProfilePublicViewComponent;
  let fixture: ComponentFixture<ProfilePublicViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfilePublicViewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfilePublicViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
