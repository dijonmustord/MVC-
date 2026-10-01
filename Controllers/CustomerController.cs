using Microsoft.AspNetCore.Mvc;
using MVC_.Data;
using Customers.Models;

 

namespace firstASP.Controllers

{

    public class CustomerController : Controller

    {

        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db) { _db = db; }

 

        // shows the list

        public IActionResult Index()

        {
            var customer = _db.Customer.ToList();

            return View(customer);

        }

 

        // shows the empty add-form

        public IActionResult Create()

        {

            return View();

        }

 

        // saves a new product

        [HttpPost]

        public IActionResult Create(Customer customer)

        {

            _db.Customer.Add(customer);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

           // EDIT - show the edit form
        public IActionResult Edit(int id)
        {
            var customer = _db.Customer.Find(id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        // EDIT - save the changes
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _db.Customer.Update(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE - remove the product
        public IActionResult Delete(int id)
        {
            var customer = _db.Customer.Find(id);
            if (customer != null)
            {
                _db.Customer.Remove(customer);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }

}