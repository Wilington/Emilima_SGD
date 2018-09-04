import { Component, Input } from '@angular/core';

@Component({
    selector: 'principal',
    templateUrl: './principal.component.html',
})
export class PrincipalComponent {
    public title;

    constructor() {
        this.title = "Bienvenido!!"
    }
}