using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartIT.Employee.MockDB;

// Copyright 2017 (c) SmartIT by John Kocer. All rights reserved.
namespace Todo.Mvc.Ui.Controllers
{
  public class TodoController : Controller
  {
    TodoRepository _todoRepository = new TodoRepository();
    // GET: Todo
    public ActionResult Index()
    {
      var todos = (List<SmartIT.Employee.MockDB.Todo>)_todoRepository.GetAll();
      return View(todos);
    }

    // GET: Todo/Details/5
    public ActionResult Details(int id)
    {
      var findTodo = _todoRepository.FindById(id);
      return View(findTodo);
    }

    // GET: Todo/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Todo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        _todoRepository.Add(new SmartIT.Employee.MockDB.Todo() { Name = collection["Name"] });

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Todo/Edit/5
    public ActionResult Edit(int id)
    {
      var findTodo = _todoRepository.FindById(id);
      return View(findTodo);
    }

    // POST: Todo/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        var findTodo = _todoRepository.FindById(id);
        findTodo.Name = collection["Name"];

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Todo/Delete/5
    public ActionResult Delete(int id)
    {
      return View(_todoRepository.FindById(id));
    }

    // POST: Todo/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        var findTodo = _todoRepository.FindById(id);
        _todoRepository.Delete(findTodo);

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}