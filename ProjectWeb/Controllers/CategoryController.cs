﻿using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Data;
using ProjectWeb.Models;

namespace ProjectWeb.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDBContext _dbContext;
		public CategoryController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			List<Category> listCategory=_dbContext.Categories.ToList();
			return View(listCategory);
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Category category)
		{
			if (category.Name.Equals(category.Description))
			{
				ModelState.AddModelError("Name", "Name should be different than Description");
			}
			if (ModelState.IsValid)
			{
				_dbContext.Categories.Add(category);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Edit(int id)
		{
			Category? category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}
		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Categories.Update(category);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Delete(int id)
		{
			Category? category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}
		[HttpPost]
		public IActionResult Delete(Category category)
		{
				_dbContext.Categories.Remove(category);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");

		}
	}
}
