import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';

@Component({
  selector: 'app-login-layout',
  templateUrl: './login-layout.component.html',
  styleUrls: ['./login-layout.component.scss'],
})
export class LoginLayoutComponent implements OnInit, AfterViewInit {
  isMobile: boolean = false;
  constructor(private ref: ChangeDetectorRef) {}

  ngAfterViewInit(): void {
    this.ref.detectChanges();
  }

  ngOnInit(): void {
    if (window.screen.width <= 401 ) {
      this.isMobile = true;
    }
  }
}
