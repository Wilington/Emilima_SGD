import { Component, ViewChild } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Headers } from '@angular/http';
import { UsuariosService } from '../../service/usuarioservice.service';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
    selector: 'usuariolista',
    templateUrl: './usuariolista.component.html',
    providers: [UsuariosService],
    styleUrls: [
        '../../../assets/css/bootstrap.min.css',
        '../../../assets/css/style.css'
    ],
})

export class UsuariolistaComponent {
    usuarioForm: FormGroup;
    public listaUsuario;
    public resultado;

    constructor(
        private _route: ActivatedRoute
        , private _router: Router
        , private _usuarioService: UsuariosService
        , private _fb: FormBuilder
    ) {
        this.usuarioForm = this._fb.group({
            us_nombre: ['', [Validators.required]],
            us_mail: ['', [Validators.required]],
            CodUsua: ['', [Validators.required]],
            us_contra: ['', [Validators.required]],
        })
        //this.listaUsuario = "En camino";
        //this.getUsuarios();
        this.getUsuarios();
    }

    getUsuarios() {
        this._usuarioService.getUsuarios().subscribe(
            result => {
                this.listaUsuario = result;
                if (!this.listaUsuario) {
                    console.log('Error en el servidor');
                }
            },
            error => {
                var r = <any>
                    error;
                console.log(r);
            }
        )
    }

    nuevoUsuario() {
        this._usuarioService.addUsuarios(this.usuarioForm.value).subscribe(
            result => {
                this.resultado = result;
                if (!this.resultado) {
                    console.log('Error en el servidor');
                    return;
                }
                this.getUsuarios();

            },
            error => {
                var r = <any>
                    error;
                console.log(r);
            }
        )
    }

    editarUsuario(usuario) {
        console.log('user: ', usuario);
        this.usuarioForm.setValue({
            us_nombre: usuario.us_nombre,
            us_mail: usuario.us_mail,
            CodUsua: usuario.CodUsua,
            us_contra: '',
        });

        this._usuarioService.editarUsuarios(this.usuarioForm.value).subscribe(
            result => {
                this.resultado = result;
                if (!this.resultado) {
                    console.log('Error en el servidor');
                    return;
                }
                this.getUsuarios();

            },
            error => {
                var r = <any>
                    error;
                console.log(r);
            }
        )
    }

    eliminarUsuario(codUsua) {
        console.log('codigo: ', codUsua);
        this._usuarioService.eliminarUsuarios(codUsua).subscribe(
            result => {
                this.resultado = result;
                if (!this.resultado) {
                    console.log('Error en el servidor');
                    return;
                }
                this.getUsuarios();

            },
            error => {
                var r = <any>
                    error;
                console.log(r);
            }
        )
    }

    get us_nombre() { return this.usuarioForm.get('us_nombre'); }
    get us_mail() { return this.usuarioForm.get('us_mail'); }
    get CodUsua() { return this.usuarioForm.get('CodUsua'); }
    get us_contra() { return this.usuarioForm.get('us_contra'); }
}

interface UsuarioData {
    us_nombre: string;
    us_mail: string;
    CodUsua: string;
    us_contraseña: string;
}