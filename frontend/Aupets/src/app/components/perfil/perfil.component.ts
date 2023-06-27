import { MessagesService } from './../../shared/services/messages.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Usuario } from 'src/app/interfaces/usuario.model';
import { UsuarioRepositoryService } from 'src/app/shared/services/usuario-repository.service';


@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css'],
})
export class PerfilComponent {
  userForm!: FormGroup;
  usuario!: Usuario;

  constructor(
    private usuarioService: UsuarioRepositoryService,
    private activatedRoute: ActivatedRoute,
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
    const userid : string = this.activatedRoute.snapshot.params['id'];
    const apiUrl: string = `api/usuario/${userid}`;

    this.usuarioService.getUsuarioById(apiUrl).subscribe({
      next: (user: Usuario) => {
        this.usuario = {
          ...user,
        };
        this.userForm.patchValue(this.usuario);
      }
    });
  }
}
