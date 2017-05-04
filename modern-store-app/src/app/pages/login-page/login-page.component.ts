import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { CustomValidator } from '../../validators/custom.validator';
import { DataService } from '../../services/data.service';
import { Ui } from '../../utils/ui';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  providers: [Ui, DataService]
})
export class LoginPageComponent implements OnInit {
  public errors: any[] = [];

  public form: FormGroup;

  constructor(private fb: FormBuilder, private ui: Ui, private dataService: DataService, private router: Router) {
    this.form = this.fb.group({
      username: ['slipalison12', Validators.compose([
        Validators.required,
        Validators.maxLength(160),
        Validators.minLength(5)
        //,        Validators.email,
        //CustomValidator.EmailValidator
      ])],

      password: ['alison', Validators.compose([
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(6)
      ])]
    });
    this.checkToken();
  }

  checkEmail() {
    console.log(this.form.controls['email'].value);
  }

  submit() {
    this.dataService.authenticate(this.form.value)
      .subscribe(result => {
        localStorage.setItem('mws.token', result.token);
        localStorage.setItem('mws.user', JSON.stringify(result.user));
        this.router.navigateByUrl('/home');
      }, error => {
        this.errors = JSON.parse(error._body).errors;
      });
  }
  checkToken() {
    let token = localStorage.getItem('mws.token');
    if (this.dataService.validateToken(token))
      this.router.navigateByUrl('/home');
  }

  ngOnInit() {

    //   this.dataService.getCourses().subscribe(result => {
    //     console.log(result);
    //   }, error => {
    //
    //   });

  }

}
