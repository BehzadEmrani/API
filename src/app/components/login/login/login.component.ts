import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormGroupDirective,
  NgForm,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(
    control: FormControl | null,
    form: FormGroupDirective | NgForm | null
  ): boolean {
    const isSubmitted = form && form.submitted;
    return !!(
      control &&
      control.invalid &&
      (control.dirty || control.touched || isSubmitted)
    );
  }
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('mydiv', { static: false })
  mydiv!: ElementRef;

  currentFrom!: FormGroup;
  isColor: boolean = false;
  isMobile: boolean = true;
  isType: string = 'password';

  userNameFormControl = new FormControl('', [
    Validators.required,
    Validators.pattern("^[a-zA-Z -']+"),
  ]);

  passwordFormControl = new FormControl('', Validators.required);

  matcher = new MyErrorStateMatcher();

  constructor(private fb: FormBuilder, private ref: ChangeDetectorRef) {}
  id: any;
  ngAfterViewInit() {
    this.id = setInterval(() => {
      this.getFormValidationErrors();
    }, 1000);
    this.ref.detectChanges();
  }

  ngOnInit(): void {
    this.initForm();
    if (window.screen.width <= 401) {
      this.isMobile = false;
    }
  }

  ngOnDestroy() {
    if (this.id) {
      clearInterval(this.id);
    }
  }
  hide: boolean = true;
  getFormValidationErrors() {
    Object.keys(this.currentFrom.controls).forEach((key) => {
      const controlErrors: any = this.currentFrom.get(key)?.errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach((keyError) => {
          if (controlErrors[keyError].actualValue) {
            console.log('hide');

            setTimeout(() => {
              this.hide = false;
            }, 1000);
          } else {
            this.hide = true;
          }
        });
      }
    });
    
  }
  initForm() {
    this.currentFrom = this.fb.group({
      userName: new FormControl('', [
        Validators.required,
        Validators.pattern("^[a-zA-Z -']+"),
      ]),
      password: new FormControl('', Validators.required),
    });
  }
  get userName() {
    return this.currentFrom.get('userName');
  }

  visibility(type: any) {
    if (type == 'password') {
      this.isColor = true;
      this.isType = 'text';
    } else {
      this.isColor = false;
      this.isType = 'password';
    }
  }

  parentContextMenu(event: any) {
    console.log(event, 'parent');
  }
}
