import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { LoginComponent } from './components/login/login.component'

@NgModule({
    bootstrap: [AppComponent,
        LoginComponent,
    ],
    imports: [
        ServerModule,
        AppModuleShared
    ]
})
export class AppModule {
}
