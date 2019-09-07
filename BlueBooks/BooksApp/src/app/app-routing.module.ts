import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { BooksComponent } from './components/book/book.component';
import { AuthGuard } from './components/auth-guard';
import { AuthorComponent } from './components/author/author.component';
import { CategoryComponent } from './components/category/category.component';

const routes: Routes = [

  { path : '', redirectTo:'/login', pathMatch : 'full'},
  { path: 'login', component: LoginComponent},
  { path: 'author', component: AuthorComponent},
  { path: 'category', component: CategoryComponent},
  { path:'book', component:BooksComponent, canActivate:[AuthGuard] }
    
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
