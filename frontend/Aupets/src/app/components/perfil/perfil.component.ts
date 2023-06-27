import { MessagesService } from './../../shared/services/messages.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UsuarioRepositoryService } from 'src/app/shared/services/usuario-repository.service';
import { UsuarioForUpdate } from 'src/app/interfaces/usuarioForUpdate.model';


@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css'],
})
export class PerfilComponent {
  userForm!: FormGroup;
  usuarioId: any = localStorage.getItem('userId');
  usuario!: UsuarioForUpdate;

  constructor(
    private usuarioService: UsuarioRepositoryService,
    private fb: FormBuilder,
    private serviceMessages: MessagesService
  ) {}

  ngOnInit(): void {
    this.userForm = this.fb.group({
      email: ['', Validators.compose([Validators.required, Validators.email])],
      nome: ['', Validators.required],
      senha: ['', Validators.required],
      nomeFantasia: [ '', Validators.required],
      razaoSocial: ['', Validators.required],
      endereco: ['', Validators.required],
      complemento: ['' ],
      bairro: ['', Validators.required],
      cidade: [ '', Validators.required],
      cep: ['', Validators.required],
      numero: ['', Validators.required],
      urlSite: [''],
      imagem: ['', Validators.required],
    });
    this.getUsuario();
  }

  getUsuario() {
    const userid = localStorage.getItem('userId');
    const apiUrl: string = `api/usuario/${userid}`;

    this.usuarioService.getUsuarioById(apiUrl).subscribe({
      next: (user: UsuarioForUpdate) => {
        this.usuario = {
          ...user,
        };
        this.userForm.patchValue(this.usuario);
      },
      error: (err) => this.serviceMessages.add(err.error)
    });
  }
}
