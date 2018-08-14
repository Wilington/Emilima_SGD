import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Headers } from '@angular/http';
import { UsuariosService } from '../../service/usuarioservice.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'usuarioform',
    templateUrl: './usuarioform.component.html',
    providers: [UsuariosService]
})

export class UsarioformComponent {
    usuarioForm: FormGroup;
    title: string = "Create";

    public resultado;

    constructor(
        private _route: ActivatedRoute
        , private _router: Router
        , private _usuarioService: UsuariosService
        , private _fb: FormBuilder
    ) {
        this.usuarioForm = this._fb.group({
            nombre: ['', [Validators.required]],
            mail: ['', [Validators.required]],
            usuario: ['', [Validators.required]],
            contra: ['', [Validators.required]],
        })
        this.nuevoUsuario();
    }

    ngOnInit() {

    }

    nuevoUsuario() {
        this._usuarioService.addUsuarios(this.usuarioForm.value).subscribe(
            result => {
                this.resultado = result;
                if (!this.resultado) {
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