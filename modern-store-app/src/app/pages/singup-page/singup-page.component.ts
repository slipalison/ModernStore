import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { CustomValidator } from '../../validators/custom.validator';
import { DataService } from '../../services/data.service';
import { Ui } from '../../utils/ui';
import { Router } from '@angular/router';

@Component({
  selector: 'app-singup-page',
  templateUrl: './singup-page.component.html',
  providers: [Ui, DataService]
})
export class SingupPageComponent implements OnInit {

  public form: FormGroup;
  public errors: any[] = [];

  constructor(private fb: FormBuilder, private ui: Ui, private dataService: DataService, private router: Router) {
    this.form = this.fb.group({
      email: ['alison@alison.com', Validators.compose([
        Validators.required,
        Validators.maxLength(160),
        Validators.minLength(5),
        Validators.email,
        CustomValidator.EmailValidator
      ])],

      password: ['alison', Validators.compose([
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(6)
      ])],
      firstName: ['alison', Validators.compose([
        Validators.required,
        Validators.maxLength(160),
        Validators.minLength(5)
      ])],
      lastName: ['amorim', Validators.compose([
        Validators.required,
        Validators.maxLength(160),
        Validators.minLength(5)
      ])],
      document: ['61334847991', Validators.compose([
        Validators.required,
        Validators.maxLength(160),
        Validators.minLength(5)
      ])],
      userName: ['slipalison12', Validators.compose([
        Validators.required,
        Validators.maxLength(160),
        Validators.minLength(5)
      ])],
      confirmPassword: ['alison', Validators.compose([
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(6)
      ])]

    });

  }

  ngOnInit() {
  }
  submit() {

    this.dataService.createUser(this.form.value).subscribe(result => {
      console.log(result);
      alert('Bem vindo ao Modern Store');
      this.router.navigateByUrl('/');
    }, error => {
      this.errors = JSON.parse(error._body).errors;
      console.log(error);
    });

  }
}
