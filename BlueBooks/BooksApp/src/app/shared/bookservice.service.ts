import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Category } from './category.model';
import { Book } from './book.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class BookserviceService {
  formData:Book;
  books: Book[];
  categories: Category[];

  constructor(private Http:HttpClient)  { }



  getAllBooks(){
    return this.Http.get(environment.ApiUrl + 'book/getbooks')
  }

  getAllCategories(categoryId:number){
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'text/html; charset=utf-8');
    let params = new HttpParams().set("categoryID",categoryId.toString());
    return this.Http.get(environment.ApiUrl + 'categories/GetCategories', {params: params}); 

  }
  getAuthors(authorid: number){

     let headers = new HttpHeaders();
     headers.append('Content-Type', 'text/html; charset=utf-8');
     let params = new HttpParams().set("authorid",authorid.toString());
     return this.Http.get(environment.ApiUrl + 'author/getAuthors', {params: params}); 
   
  }

  createBook(book:Book){
    return this.Http.post<any>(environment.ApiUrl + 'book/create',book);

  }
  createCategory(category:Category){
    return this.Http.post<any>(environment.ApiUrl + 'categories/createCategory',category);
  }
}

