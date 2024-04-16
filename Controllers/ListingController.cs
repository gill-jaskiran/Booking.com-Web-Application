using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
	public class ListingController : Controller
	{

		private readonly AppDbContext _db;
		public ListingController(AppDbContext db)
		{
			_db = db;
		}


        [HttpGet("Index")]
        public IActionResult Index(string searchName, string filterType)
        {
            var listings = _db.Listings.ToList();

            // Apply search by name
            if (!string.IsNullOrEmpty(searchName))
            {
                listings = listings.Where(l => l.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Apply filter by type
            if (!string.IsNullOrEmpty(filterType))
            {
                listings = listings.Where(l => l.Type == filterType).ToList();
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest") // sees if its a ajax request
            {
                // AJAX Request will return partial veiw
                
                return PartialView("_ListingsPartial", listings);
            }

            return View(listings); 
        }

        [HttpGet("Details/{id}")]
		public IActionResult Details(int id)
		{
			var project = _db.Listings.SingleOrDefault(p => p.ListingId == id);
			if (project == null)
			{
				return NotFound();
			}
			return View(project);
		}

		[HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
		{
			return View();
		}


        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Listing listing)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Listings.Add(listing);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(listing);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                ModelState.AddModelError("", "An error occurred while creating the listing. Please try again later.");
                return View(listing);
            }
        }

        [HttpGet("Edit/{id}")]
		public IActionResult Edit(int id)
		{
			var project = _db.Listings.Find(id);
			if (project == null)
			{
				return NotFound();
			}
			return View(project);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("ListingId, Type, Name, Description, Price")] Listing listing)
		{
			if (id != listing.ListingId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_db.Update(listing);
					_db.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ListingExists(listing.ListingId))
					{
						return NotFound(listing);
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(listing);
		}

		private bool ListingExists(int id)
		{
			return _db.Listings.Any(e => e.ListingId == id);
		}

		[HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
		{
			var listing = _db.Listings.FirstOrDefault(p => p.ListingId == id);
			if (listing == null)
			{
				return NotFound();
			}
			return View(listing);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int ListingId)
		{
			var listing = _db.Listings.Find(ListingId);
			if (listing != null)
			{
				_db.Listings.Remove(listing);
				_db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return NotFound();
		}

       
    }
}

