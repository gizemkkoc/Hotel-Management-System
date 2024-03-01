using HotelManagementSystem.Models;
using HotelManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IRepository<Customers> _customerRepository;

            
        public CustomersController(IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult GetAllCustomers()
        {
            var customer = _customerRepository.GetAll();
            return View(customer);
        }
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customers customer)
        {
            if (customer == null)
            {
                Console.WriteLine("Müşteri bilgileri boş olamaz");
            }
            _customerRepository.Add(customer);
            return RedirectToAction(nameof(GetAllCustomers));

        }

        public IActionResult UpdateCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(int id, Customers customer)
        {
            if (customer == null || id != customer.CustomerId)
            {
                Console.WriteLine("Geçersiz işlem");
            }
            var existingCustomer = _customerRepository.GetById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerRepository.Update(customer);
            return RedirectToAction(nameof(GetAllCustomers));
        }
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerRepository.Delete(id);
            return View(customer);
            //return RedirectToAction(nameof(GetAllCustomers));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
