import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Headers } from '@angular/http';
import { UsuariosService } from '../../service/usuarioservice.service';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    providers: [UsuariosService],
    styleUrls: [
        //'../../../assets/css/font-awesome.min.css',
        '../../../assets/css/style.css',
        '../../../assets/css/bootstrap.min.css',
        '../../../assets/css/mdb.css'
    ],
    
})

export class LoginComponent {
    loginForm: FormGroup;
    public resultado;
    public Usuario;
    public Contra;
    
    
    constructor(
        private _route: ActivatedRoute
        , private _router: Router
        , private _usuarioService: UsuariosService
        , private _fb: FormBuilder
    ) {
        console.log(this.Contra);
        this.Contra = 'Hola';
        this.loginForm = this._fb.group({
            us_usuario: ['', [Validators.required]],
            us_contra: ['', [Validators.required]],
        })
        this.validaUsuario();
    }

    ngOnInit() {
        console.log('hola2');
    }

    prueba() {
        console.log('wili');
    }

    validaUsuario() {
        console.log(this.loginForm.value);
        this._usuarioService.ValidaUsuario(this.loginForm.value).subscribe(
            result => {
                this.resultado = result;
                if (!this.resultado) {
                    console.log('Error!.. No hubo respuesta en Login.')
                }
            }, 
            error => {
                var r = <any>
                    error;
                console.log(r);
            }
        )
    }
    get us_usuario() { return this.loginForm.get('us_usuario'); }
    get us_contra() { return this.loginForm.get('us_contra'); }
}
