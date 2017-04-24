import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms'

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html'
})
export class LoginPageComponent implements OnInit {

  public form: FormGroup;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      email: ['', Validators.compose([
        Validators.required,
        Validators.maxLength(160),
        Validators.minLength(5), 
        Validators.email
      ])],

      password: ['', Validators.compose([
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(6)
      ])]
    });

  }

  ngOnInit() { }

}
