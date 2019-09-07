import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { NgForm } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http/http';
import { Book } from 'src/app/shared/book.model';
import { Category } from 'src/app/shared/category.model';
import { Author } from 'src/app/shared/author.model';
import { Login } from 'src/app/shared/login.model';
import { BookserviceService } from 'src/app/shared/bookservice.service';
import { LoginService } from 'src/app/shared/login.service';
import { BookEditComponent } from './book-edit/book-edit.component';



@Component({
  selector: 'app-books',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BooksComponent implements OnInit {

  formData:Book;
  booksList:Book[] = [];
  loginobj: Login;
  isValid:boolean =  false;

  constructor(private bookService:BookserviceService, 
    public dialog : MatDialog, 
    private loginService: LoginService) { }

  ngOnInit() {
    this.formData = {
        bookId : 0,
        title:'',
        authorID:0,
        categoryId:0
    }
  
    
    this.bookService.getAllBooks().subscribe((data: Book[]) => 
    {
  
      this.booksList = data;
      console.log(data);    
    }, (error: any) => {   
      console.log(error)
    }
  );
    
    //this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form=null){
      form.resetForm();
    }
    else{
      this.formData ={
        bookId : 0,
        title:'',
        authorID:0,
        categoryId:0

      }
    }

  }

  AddNewBook(){
 
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    this.dialog.open(BookEditComponent,dialogConfig);

  }

 

}

