import { Component, OnInit, Inject } from '@angular/core';
import { Category } from 'src/app/shared/category.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BookserviceService } from 'src/app/shared/bookservice.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-categoryedit',
  templateUrl: './categoryedit.component.html',
  styleUrls: ['./categoryedit.component.css']
})
export class CategoryeditComponent implements OnInit {
  formData:Category;
  action:string;
  local_data:any;
 
  
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Category,
    public dialogRef: MatDialogRef<CategoryeditComponent>,
    private bookService:BookserviceService,
    private toastService:ToastrService
  ) {
      this.local_data = {...data};
      this.action = this.local_data.action;
   }

  ngOnInit() {

      this.formData = {
        categoryId : 0,
        categoryName : ''
      }
  }
  onSubmit(nform:NgForm){
    console.log(this.formData);
    this.bookService.createCategory(this.formData)
    .subscribe(
        
        data => { 
          this.dialogRef.close({event:'Add',data:this.local_data});
          this.toastService.success("the record has been inserted")
        //this.resetForm();
      },
        error => this.toastService.error(error)
    )
  }

}
