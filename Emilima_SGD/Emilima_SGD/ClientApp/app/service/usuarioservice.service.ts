import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { getBaseUrl } from '../app.browser.module';

@Injectable()
export class UsuariosService {
    myAppUrl: string = "";

    constructor(private _http: Http,
        @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getUsuarios() {
        return this._http.get(this.myAppUrl + 'api/Usuario/Index')
            .map(resp => resp.json())
            .catch(this.errorHandler);
    }

    addUsuarios(usuario) {
        //let headers = new Headers({ 'Content-Type': 'application/json' });
        //let options = new RequestOptions({ headers: headers });
        //let body = JSON.stringify(usuario);
        return this._http.post(this.myAppUrl + 'api/Usuario/Nuevo', usuario)
            .map(resp => resp.json())
            .catch(this.errorHandler);
    }

    editarUsuarios(usuario) {
        return this._http.post(this.myAppUrl + 'api/Usuario/Editar', usuario)
            .map(resp => resp.json())
            .catch(this.errorHandler);
    }

    eliminarUsuarios(usuario) {
        return this._http.post(this.myAppUrl + 'api/Usuario/Eliminar', usuario)
            .map(resp => resp.json())
            .catch(this.errorHandler);
    }

    ValidaUsuario(login) {
        let result = this._http.post(this.myAppUrl + 'api/Usuario/Valida', login);       
        return result
            .map(resp => resp.text())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}