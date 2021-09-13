import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DataService } from './services/data.service';
import { Todo } from './todo.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'TodoFE';

  constructor(public service:DataService){
  }

  ngOnInit(): void {
    this.service.getList();
  }

  onSubmit(form:NgForm){
    if(this.service.todoData.id==0){
      this.insertRecord(form);
    }
    else{
      this.updateRecord(form);
    }
  }

  insertRecord(form:NgForm){
    this.service.postTodo().subscribe(
      res=>{
        console.log(res);
        this.resetForm(form);
        this.service.getList();
      },
      err=>{
        console.log(err)
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.patchTodo().subscribe(
      res=>{
        console.log(res);
        this.resetForm(form);
        this.service.getList();
      },
      err=>{
        console.log(err)
      }
    );
  }


  resetForm(form:NgForm){
    form.form.reset();
    this.service.todoData= new Todo();
  }

  populateForm(selectedTodo:Todo){
    this.service.todoData=Object.assign({},selectedTodo) ;

  }

  onDelete(id:number){
    this.service.deleteTodo(id).subscribe(
      res=>{
        this.service.getList();
        console.log(res);
    },
    err=>{
      console.log(err);
    }
    )
  }


}
