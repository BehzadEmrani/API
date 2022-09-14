import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormGroupDirective,
  NgForm,
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
export class LoginComponent implements OnInit, AfterViewInit {
  currentFrom!: FormGroup;
  isColor: boolean = false;
  isType: string = 'password';

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);
  passwordFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  matcher = new MyErrorStateMatcher();

  constructor(
    private fb: FormBuilder,
    private ref: ChangeDetectorRef,

  ) {

  }

  ngAfterViewInit() {
    this.ref.detectChanges();
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.currentFrom = new FormGroup({
      email: new FormControl('', [
        Validators.required,
        Validators.email,
        Validators.pattern("^[a-zA-Z -']+"),
      ]),
      password: new FormControl('', Validators.required),
    });
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

}
