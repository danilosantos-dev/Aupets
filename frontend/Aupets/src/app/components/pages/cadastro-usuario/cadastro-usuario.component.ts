import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Usuario } from 'src/app/interfaces/usuario.model';
import { UsuarioRepositoryService } from 'src/app/shared/services/usuario-repository.service';
import { UsuarioForCreation } from 'src/app/interfaces/usuarioForCreation.model';
import { MessagesService } from 'src/app/shared/services/messages.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styleUrls: ['./cadastro-usuario.component.css'],
})
export class CadastroUsuarioComponent {
  registerForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioRepositoryService,
    private messagesService: MessagesService,
    private router : Router,
    private authService: AuthService

  ) { }

  ngOnInit() {
    this.registerForm = this.fb.group({
      nome: ['', Validators.required],
      email: ['', Validators.compose([Validators.required, Validators.email])],
      senha: [
        '',
        Validators.compose([Validators.required, Validators.minLength(8)]),
      ],
      confirmPassword: ['', Validators.required],
      terms: ['', Validators.required],
    });
  }

  checkName() {
    return (
      this.registerForm.controls['nome'].dirty &&
      this.registerForm.hasError('required', 'nome')
    );
  }

  checkEmail() {
    return (
      this.registerForm.controls['email'].dirty &&
      this.registerForm.hasError('required', 'email')
    );
  }

  checkEmailValid() {
    return (
      this.registerForm.controls['email'].dirty &&
      this.registerForm.hasError('email', 'email')
    );
  }

  checkPassword() {
    return (
      this.registerForm.controls['senha'].dirty &&
      this.registerForm.hasError('required', 'senha')
    );
  }

  checkPasswordValid() {
    return (
      this.registerForm.controls['senha'].dirty &&
      this.registerForm.hasError('minlength', 'senha')
    );
  }

  checkConfirmPassword() {
    return (
      this.registerForm.controls['confirmPassword'].dirty &&
      this.registerForm.hasError('required', 'confirmPassword')
    );
  }

  checkConfirmPasswordEqual() {
    const password = this.registerForm.get('senha')?.value;
    const confirmPassword = this.registerForm.get('confirmPassword')?.value;
    if (password === confirmPassword) {
      return false;
    } else {
      return true;
    }
  }

  checkTerms() {
    return (
      this.registerForm.controls['terms'].dirty &&
      this.registerForm.hasError('required', 'terms')
    );
  }

  onSubmit() {
    if (this.registerForm.valid) {
      //ENVIAR DADOS PARA A API
      this.criarUsuario();
    } else {
      //Disparo do erro
      this.validateAllFormFields(this.registerForm);
    }
  }

  criarUsuario(): void {
    const apiUrl = 'api/usuario';
    const usuario: UsuarioForCreation = this.registerForm.value;
    this.usuarioService.createUsuario(apiUrl, usuario).subscribe({
      next: () => {
        this.registerForm.reset();
        this.messagesService.add('Cadastro realizado com sucesso');
      }, 
      error: (err) => {
        this.messagesService.add(err.error);
      }
    });
  }

  //Percorre o formulario e valida os inputs caso estejam vazios
  private validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach((field) => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      }
    });
  }
}
