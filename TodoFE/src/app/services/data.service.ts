import { Injectable } from '@angular/core';
import { Todo } from '../todo.model';
import {HttpClient} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http:HttpClient) { }
  // url
  baseURL = "https://localhost:44380/api/todos";

  // for form post
  todoData:Todo=new Todo();

  // list for view
  list: Todo[] | undefined;


  // post
  postTodo(){
    return this.http.post(this.baseURL,this.todoData)
  }

  // get
  getList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res=>this.list=res as Todo[]);
  }

  // patch
  patchTodo(){
    return this.http.patch(`${this.baseURL}/${this.todoData.id}`,this.todoData);
  }

  // delete
  deleteTodo(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}

