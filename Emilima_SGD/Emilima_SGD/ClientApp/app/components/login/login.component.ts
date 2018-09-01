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
    public resultado;

    constructor() {

    }

    validaUsuario() {

    }
}