using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Runtime.Caching;
using System.Collections.Generic;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Form to add new customers
        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel {
                Customer = new Customer(),
                MembershipTypes = MembershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        //handles insertion in the New Action Result
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            
            //validation
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var CustomersInDb = _context.Customers.Single(c => c.Id == customer.Id);

                CustomersInDb.Name = customer.Name;
                CustomersInDb.DateOfBirth = customer.DateOfBirth;
                CustomersInDb.MembershipTypeID = customer.MembershipTypeID;
                CustomersInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        //return the list of customers

        public ActionResult Index()
        {   
            if(MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }

            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }

        //return customer details based on id
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
  
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}