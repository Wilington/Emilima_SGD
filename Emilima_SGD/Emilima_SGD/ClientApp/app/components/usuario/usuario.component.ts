import { Component, ViewChild } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Headers } from '@angular/http';
import { UsuariosService } from '../../service/usuarioservice.service';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
    selector: 'usuario',
    templateUrl: './usuario.component.html',
    providers: [UsuariosService],
    styleUrls: [
        //'../../../assets/css/font-awesome.min.css',
        //'../../../assets/css/style.css',
        '../../../assets/css/bootstrap.min.css',
        //'../../../assets/css/mdb.css'
    ],
})

export class UsuarioComponent {
    public Lista_Usuario;
    public Nuevo_Usuario;
    public listaUsuario;
    public resultado;

    constructor(
        private _route: ActivatedRoute
        , private _router: Router
        , private _usuarioService: UsuariosService
        , private _fb: FormBuilder
    ) {
        //this.listaUsuario = "En camino";
        //this.getUsuarios();
        this.Lista_Usuario = true;
        this.Nuevo_Usuario = false;
        this.getUsuarios();
    }

    cambioNuevo() {
        this.Lista_Usuario = false;
        this.Nuevo_Usuario = true;
    }

    cambioLista() {
        this.Lista_Usuario = true;
        this.Nuevo_Usuario = false;
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
}
