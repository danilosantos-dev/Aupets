import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators  } from '@angular/forms';

@Component({
  selector: 'app-cadastro-prestador',
  templateUrl: './cadastro-prestador.component.html',
  styleUrls: ['./cadastro-prestador.component.css']
})
export class CadastroPrestadorComponent {

  companyRegisterForm!: FormGroup;

  constructor(private fb: FormBuilder){}

  ngOnInit(){
    this.companyRegisterForm = this.fb.group({
      socialReason: ['', Validators.required],
      fantasyName: ['', Validators.required],
      typePerson: ['', Validators.required],
      cpfCnpj: ['', Validators.compose([ Validators.required,  ])],
      address: ['', Validators.required ],
      neighborhood: ['', Validators.required],
      city: ['', Validators.required],
      cep: ['', Validators.required],
      number: ['', Validators.required],
      occupation: ['', Validators.required],
      specialization: ['', Validators.required],
      image: ['', Validators.required],
      terms: ['', Validators.required]
    })
  }

  //Todo: Funções que checam os campos e se estão validos

  checkReason(){
    return this.companyRegisterForm.controls['socialReason'].dirty && this.companyRegisterForm.hasError('required' , 'socialReason');
  }


  checkTerm(){
    return this.companyRegisterForm.controls['terms'].dirty && this.companyRegisterForm.hasError('required' , 'terms');
  }


  onSubmit(){
    if (this.companyRegisterForm.valid) {
      //ENVIAR DADOS PARA A API
      console.log(this.companyRegisterForm.value)
    } else {
      //Disparo do erro
      this.validateAllFormFields(this.companyRegisterForm)
    }
  }

   //Percorre o formulario e valida os inputs caso estejam vazios
   private validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      }
    });
  }
}
