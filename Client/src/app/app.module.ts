import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {  ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms'

import { LoginComponent } from './login/login.component';
import { Page404Component } from './page404/page404.component';
import { TestComponent } from './test/test.component';
import { LayoutModule } from './layout/layout.module';
import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RunProcessComponent } from './run-process/run-process.component';
import { SearchListComponent } from './common/search/search-list.component';
import { SelectComponent } from './common/select/select.component';
import { CustomCommonModule } from './common/common.module';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    Page404Component,
    TestComponent,
     
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    LayoutModule,
    ClarityModule,
    BrowserAnimationsModule,
   
  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
