import { BrowserModule } from '@angular/platform-browser';
import { NgModule,CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatListModule, MatDialogModule } from '@angular/material';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthInterceptor } from './components/auth-interceptor';
import { AuthGuard } from './components/auth-guard';
import { LoginService } from './shared/login.service';
import { BookEditComponent } from './components/book/book-edit/book-edit.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BooksComponent } from './components/book/book.component';
import { AuthorComponent } from './components/author/author.component';
import { SelecRequiredValidatorDirective } from './shared/selected-required-validator.directive';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ToastrModule } from 'ngx-toastr';
import { CategoryComponent } from './components/category/category.component';
import { CategoryeditComponent } from './components/category/categoryedit/categoryedit.component';


@NgModule({
  declarations: [
    AppComponent,
    BookEditComponent,
    LoginComponent,
    BooksComponent,
    HomeComponent,
    CategoryComponent,
    AuthorComponent,
    SelecRequiredValidatorDirective,
    NavbarComponent,
    CategoryeditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatListModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    ToastrModule.forRoot()
  ],
  exports:[
    MatListModule
  ],
  entryComponents:[
    BookEditComponent,
    CategoryeditComponent],
  providers: [
    AuthGuard,
    LoginService,
   ,{
    provide : HTTP_INTERCEPTORS,
    useClass : AuthInterceptor,
    multi : true
   }],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  bootstrap: [AppComponent]
})
export class AppModule { }
