import { Component, OnInit } from '@angular/core';
import { BookserviceService } from 'src/app/shared/bookservice.service';
import { Category } from 'src/app/shared/category.model';
import { ToastrService } from 'ngx-toastr';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { CategoryeditComponent } from './categoryedit/categoryedit.component';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categoryList:Category[] = [];

  constructor(private categoryService: BookserviceService,
    private toastService: ToastrService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.getCategories();
  }

  AddOrEditCategory(action,obj){
 
    obj.action = action;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    //dialogConfig.width = "50%";
    //this.dialog.open(CategoryeditComponent,dialogConfig);
    const dialogRef = this.dialog.open(CategoryeditComponent, {
      width: '50%',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      
      if (!(result == undefined)){
        if(result.event == 'Add'){
          this.getCategories();
          //this.addRowData(result.data);
        }else if(result.event == 'Update'){
          //((this.updateRowData(result.data);
        }else if(result.event == 'Delete'){
          //this.deleteRowData(result.data);
        }
    }
    });
  }

  getCategories(){

    this.categoryService.getAllCategories(0).subscribe((data:Category[]) =>
    {

      this.categoryList = data;

    }, error => {
        this.toastService.error(error);
    }
    )
  }

  }
  
