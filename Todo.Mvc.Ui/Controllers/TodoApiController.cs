//Copyright 2017 (c) SmartIT. All rights reserved.
//By John Kocer
// This file is for Swagger test, this application does not use this file
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartIT.Employee.MockDB; 

namespace TodoAngular.Ui.Controllers
{
  [Produces("application/json")]
  [Route("api/Todo")]
  public class TodoApiController : Controller
  {
    TodoRepository _todoRepository = new TodoRepository();

    [Route("~/api/GetAllTodos")]
    [HttpGet]
    public IEnumerable<SmartIT.Employee.MockDB.Todo> GetAllTodos()
    {
      return _todoRepository.GetAll();
    }

    [Route("~/api/AddTodo")]
    [HttpPost]
    public SmartIT.Employee.MockDB.Todo AddTodo([FromBody]SmartIT.Employee.MockDB.Todo item)
    {
      return _todoRepository.Add(item);
    }

    [Route("~/api/UpdateTodo")]
    [HttpPut]
    public SmartIT.Employee.MockDB.Todo UpdateTodo([FromBody]SmartIT.Employee.MockDB.Todo item)
    {
      return  _todoRepository.Update(item);
    }

    [Route("~/api/DeleteTodo/{id}")]
    [HttpDelete]
    public void Delete(int id)
    {
      var findTodo = _todoRepository.FindById(id);
      if (findTodo != null)
        _todoRepository.Delete(findTodo);
    }
  }
}
