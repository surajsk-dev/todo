using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Data;
using TodoBE.Models;

namespace TodoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoData _todoData;

        public TodosController(ITodoData todoData)
        {
            _todoData = todoData;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok(_todoData.GetTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetTodo(int id)
        {
            var todo = _todoData.GetTodo(id);
            if(todo != null)
            {
                return Ok(todo);

            }
            else
            {
                return NotFound($"Not Found");
            }
        }

        [HttpPost]
        public IActionResult GetTodo(Todo todo)
        {
           _todoData.AddTodo(todo);

            return Created(HttpContext.Request.Scheme+ "://" +HttpContext.Request.Host+ HttpContext.Request.Path+"/"+todo.Id,todo.Id);
          
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var todo = _todoData.GetTodo(id);
            if (todo != null)
            {
                _todoData.DeleteTodo(todo);
                return Ok();
            }
            return NotFound($"not found");

        }


        [HttpPatch("{id}")]
        public IActionResult EditTodo(int id, Todo todo)
        {
            var existingTodo = _todoData.GetTodo(id);
            if (existingTodo != null)
            {
                todo.Id = existingTodo.Id;
                _todoData.EditTodo(todo);
                return Ok();
            }
            return NotFound($"not found");

        }
    }
}
