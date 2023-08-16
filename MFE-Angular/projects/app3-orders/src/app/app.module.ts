import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import { UtilsModule } from 'projects/utils/src/public-api';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UtilsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
