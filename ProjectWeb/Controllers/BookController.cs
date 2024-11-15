using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Data;
using ProjectWeb.Models;

namespace ProjectWeb.Controllers
{
	public class BookController : Controller
	{
		private readonly ApplicationDBContext _dbContext;
		public BookController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			List<Book> listBook = _dbContext.Books.Include("Category").ToList();
			return View(listBook);
		}
		public IActionResult Add()
		{
			BookVM bookVM = new BookVM()
			{
				Categories = _dbContext.Categories.Select(c => new SelectListItem()
				{
					Text = c.Name,
					Value = c.Id.ToString()
				}),
				Book = new Book()
			};
			return View(bookVM);
		}
		[HttpPost]
		public IActionResult Add(Book Book)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Books.Add(Book);
				_dbContext.SaveChanges();
				TempData["success"] = "Book is added succesfully";
				return RedirectToAction("Index");
			}
			BookVM bookVM = new BookVM()
			{
				Categories = _dbContext.Categories.Select(c => new SelectListItem()
				{
					Text = c.Name,
					Value = c.Id.ToString()
				}),
				Book = new Book()
			};
			return View(bookVM);
		}
		public IActionResult Edit(int id)
		{
			BookVM bookVM = new BookVM()
			{
				Categories = _dbContext.Categories.Select(c => new SelectListItem()
				{
					Text = c.Name,
					Value = c.Id.ToString()
				}),
				Book = _dbContext.Books.FirstOrDefault(c => c.Id == id)
			};
			if (bookVM.Book == null)
			{
				return NotFound();
			}
			return View(bookVM);
		}
		[HttpPost]
		public IActionResult Edit(Book Book)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Books.Update(Book);
				_dbContext.SaveChanges();
				TempData["success"] = "Book is updated succesfully";
				return RedirectToAction("Index");
			}
			TempData["failed"] = "Book can not be updated";
			return View();
		}
		public IActionResult Delete(int id)
		{
			Book? Book = _dbContext.Books.FirstOrDefault(c => c.Id == id);
			if (Book == null)
			{
				return NotFound();
			}
			return View(Book);
		}
		[HttpPost]
		public IActionResult Delete(Book Book)
		{
			_dbContext.Books.Remove(Book);
			_dbContext.SaveChanges();
			TempData["success"] = "Book is deleted succesfully";
			return RedirectToAction("Index");

		}
	}
}
