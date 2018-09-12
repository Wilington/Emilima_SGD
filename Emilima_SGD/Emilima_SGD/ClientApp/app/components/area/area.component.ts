import { Component, Input } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Headers } from '@angular/http';
import { UsuariosService } from '../../service/usuarioservice.service';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ELEMENT_PROBE_PROVIDERS } from '@angular/platform-browser/src/dom/debug/ng_probe';
import { elementDef } from '@angular/core/src/view';

@Component({
    selector: 'area',
    templateUrl: './area.component.html',
    providers: [UsuariosService],

})

export class AreaComponent {
    areaForm: FormGroup;
    public submitted = false;
    public resultado;
    isLogged = false;

    @Input() loginModel: any = { user: '', password: '' };

    constructor(
        private _route: ActivatedRoute
        , private _router: Router
        , private _usuarioService: UsuariosService
        , private _fb: FormBuilder
    ) {
        this.areaForm = this._fb.group({
            us_usuario: ['', [Validators.required]],
            us_contra: ['', [Validators.required]],
        })
    }

    get f() { return this.areaForm.controls; }

    NuevaArea() {
        this.submitted = true;
        if (this.areaForm.invalid) {
            return;
        }

        console.log(this.areaForm.value);
        this._usuarioService
            .ValidaUsuario(this.areaForm.value)
            .subscribe(result => {
                if (!result) {
                    console.log('Error!.. No hubo respuesta en Login.')
                    return;
                }

                if (result == 'SI') {
                    this.isLogged = true;
                    this._router.navigate(['/usuario/']);
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
