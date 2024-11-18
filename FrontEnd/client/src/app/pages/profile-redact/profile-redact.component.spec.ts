import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileRedactComponent } from './profile-redact.component';

describe('ProfileRedactComponent', () => {
  let component: ProfileRedactComponent;
  let fixture: ComponentFixture<ProfileRedactComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfileRedactComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfileRedactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
