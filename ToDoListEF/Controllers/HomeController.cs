using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoListEF.Models;
using ToDoListEF.Data;

namespace ToDoListEF.Controllers
{
	public class HomeController : Controller
	{
		private readonly TodolistDbContext _context;

		public HomeController(TodolistDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var todoList = _context.Todos.ToList();
			return View(new TodoViewModel { TodoList = todoList });
		}

		[HttpGet]
		public JsonResult PopulateForm(int id)
		{
			var todo = _context.Todos.Find(id);
			return Json(todo);
		}

		public IActionResult Insert(TodoModel todo)
		{
			_context.Todos.Add(todo);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		 
		public IActionResult Delete(int id)
		{
			var todo = _context.Todos.Find(id);
			if (todo != null)
			{
				_context.Todos.Remove(todo);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}

		public IActionResult Update(TodoModel todo)
		{

			_context.Todos.Update(todo);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}