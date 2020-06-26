import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {  ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms'
import { EffectsModule } from '@ngrx/effects';

import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainPageModule } from './pages/main-page/main-page.module';
import { Page404Component } from './pages/page404/page404.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthEffects } from './store/effects/auth.effects';
import { StoreModule } from '@ngrx/store';
import { reducers } from './store/app.states';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    Page404Component,
     
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MainPageModule,
    ClarityModule,
    BrowserAnimationsModule,
    EffectsModule.forRoot([AuthEffects]),
    StoreModule.forRoot( reducers, {})
  ],
  providers: [
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
