using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Models;

namespace TodoBE.Data
{
    public interface ITodoData
    {
        List<Todo> GetTodos();

        Todo GetTodo(int id);

        Todo AddTodo(Todo todo);

        void DeleteTodo(Todo todo);

        Todo EditTodo(Todo todo);
    }
}
