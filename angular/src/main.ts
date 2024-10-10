import { enableProdMode, importProvidersFrom } from '@angular/core';
import { environment } from './environments/environment';
import { AppComponent } from './app/app.component';
import { ToastrModule } from 'ngx-toastr';
import { withInterceptorsFromDi, provideHttpClient } from '@angular/common/http';
import {  bootstrapApplication } from '@angular/platform-browser';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ConsultaResolve } from './app/consulta/services/consulta.resolve';
import { provideRouter } from '@angular/router';
import { APP_ROUTES } from './app/app-routing';

if (environment.production) {
  enableProdMode();
}

bootstrapApplication(AppComponent, {
    providers: [
        importProvidersFrom(ToastrModule.forRoot({
            timeOut: 3000,
            positionClass: 'toast-top-center',
            preventDuplicates: true,
            progressBar: true
        })),
        ConsultaResolve, BsModalService,
        provideHttpClient(withInterceptorsFromDi()),
        provideRouter(APP_ROUTES)
    ]
})
  .catch(err => console.error(err));
