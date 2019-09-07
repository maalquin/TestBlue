import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Category } from 'src/app/shared/category.model';
import { Author } from 'src/app/shared/author.model';
import { BookserviceService } from 'src/app/shared/bookservice.service';
import { Book } from 'src/app/shared/book.model';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent implements OnInit {
  categoryList: Category[];
  authorList: Author[];
  formData:Book;
  
  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    public dialogRef: MatDialogRef<BookEditComponent>,
    private bookService:BookserviceService,
    private toastService:ToastrService
  ) { }

  ngOnInit() {
    this.loadAuthors(0);
    this.loadCategories(0);

    this.formData = {
      bookId : 0,
      title:'',
      authorID:0,
      categoryId:0
  }
}
loadCategories(categoryID:number){
  this.bookService.getAllCategories(categoryID).subscribe((
    data: Category[]) =>
    {
      this.categoryList = data;
      console.log(data);
    },(error: any) => {
      console.log(error)
    }
  );
}

loadAuthors(authorId: number){

  this.bookService.getAuthors(authorId).subscribe((
    data: Author[]) =>
    {
      this.authorList = data;
      console.log(data);
    },(error: any) => {
      console.log(error)
    }
  );
}
onSubmit(nform:NgForm){
  console.log(this.formData);

  this.bookService.createBook(this.formData)
  .subscribe(
      
      data => { this.toastService.success("the record has been inserted"),
      this.resetForm();
    },
      error => this.toastService.error(error)
  )
}
resetForm(form?:NgForm){
  if (form=null)
    form.resetForm();
    this.formData = {
      bookId : 0,
      title:'',
      authorID:0,
      categoryId:0
  }
}

}
