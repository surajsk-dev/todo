using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Models;

namespace TodoBE.Data
{
    public class MockTodoData : ITodoData
    {

        private List<Todo> todos = new List<Todo>()
        {
            new Todo()
            {
                Id=1,
                TodoName="suraj"

            },
            new Todo()
            {
                Id=2,
                TodoName="shiva"

            }
        };

        public Todo AddTodo(Todo todo)
        {
             todos.Add(todo);
            return todo;
            
        }

        public void DeleteTodo(Todo todo)
        {
            todos.Remove(todo);
        }

        public Todo EditTodo(Todo todo)
        {
            var existingTodo = GetTodo(todo.Id);
            existingTodo.TodoName = todo.TodoName;
            return existingTodo;
        }

        public Todo GetTodo(int id)
        {
            return todos.SingleOrDefault(x => x.Id == id);
        }

        public List<Todo> GetTodos()
        {
            return todos;
        }
    }
}
