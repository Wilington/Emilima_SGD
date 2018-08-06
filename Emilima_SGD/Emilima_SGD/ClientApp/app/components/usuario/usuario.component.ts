import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Headers } from '@angular/http';
import { UsuariosService } from '../../service/usuarioservice.service';

@Component({
    selector: 'usuario',
    templateUrl: './usuario.component.html',
    providers: [UsuariosService]
})

export class UsuarioComponent {
    public listaUsuario;

    constructor(
        private _route: ActivatedRoute,
        private _router: Router,
        private _usuarioService: UsuariosService,
    ) {
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
}
