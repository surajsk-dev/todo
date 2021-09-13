using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Models;

namespace TodoBE.Data
{
    public class SqlTodoData : ITodoData
    {
        private readonly TodoContext _ctx;

        public SqlTodoData(TodoContext ctx)
        {
            _ctx = ctx;
        }
        public Todo AddTodo(Todo todo)
        {
            _ctx.Todos.Add(todo);
            _ctx.SaveChanges();
            return todo;
        }

        public void DeleteTodo(Todo todo)
        {
            _ctx.Todos.Remove(todo);
            _ctx.SaveChanges();
        }

        public Todo EditTodo(Todo todo)
        {
            var existingTodo = _ctx.Todos.Find(todo.Id);
            if(existingTodo != null)
            {
                existingTodo.TodoName = todo.TodoName;
                _ctx.Todos.Update(existingTodo);
                _ctx.SaveChanges();
            }
            return todo;
        }

        public Todo GetTodo(int id)
        {
            var todo = _ctx.Todos.Find(id);
            return todo;
        }

        public List<Todo> GetTodos()
        {
            return _ctx.Todos.ToList();
        }
    }
}
