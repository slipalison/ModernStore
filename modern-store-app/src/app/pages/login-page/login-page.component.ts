import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { CustomValidator } from '../../validators/custom.validator';
import { DataService } from '../../services/data.service';
import { Ui } from '../../utils/ui';
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  providers: [Ui, DataService]
})
export class LoginPageComponent implements OnInit {

  public form: FormGroup;

  constructor(private fb: FormBuilder, private ui: Ui, private dataService: DataService) {
    this.form = this.fb.group({
      email: ['', Validators.compose([
        Validators.required,
        Validators.maxLength(160),
        Validators.minLength(5),
        Validators.email,
        CustomValidator.EmailValidator
      ])],

      password: ['', Validators.compose([
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(6)
      ])]
    });

  }

  checkEmail() {
    console.log(this.form.controls['email'].value);
  }

  submit() {
    this.dataService.createUser(this.form.value)
  }
  ngOnInit() {

    this.dataService.getCourses().subscribe(result => {
      console.log(result);
    }, error => {

    });

  }

}
