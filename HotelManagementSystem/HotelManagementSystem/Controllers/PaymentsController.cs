using HotelManagementSystem.Models;
using HotelManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IRepository<Payments> _paymentRepository;
            
        public PaymentsController(IRepository<Payments> paymentRepository)
        {
            _paymentRepository = paymentRepository;

        }
        public IActionResult GetAllPayments()
        {
            var payment = _paymentRepository.GetAll();
            return View(payment);
        }
        public IActionResult AddPayment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPayment(Payments payment)
        {
            if (payment == null)
            {
                Console.WriteLine("Payment boş olamaz");
            }
            _paymentRepository.Add(payment);
            return RedirectToAction(nameof(GetAllPayments));

        }
        public IActionResult UpdatePayment(int id)
        {
            var payment = _paymentRepository.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }
        [HttpPost]
        public IActionResult UpdatePayment(int id, Payments payment)
        {
            if (payment == null || id != payment.PaymentID)
            {
                Console.WriteLine("Geçersiz işlem");
            }
            var existingPayment = _paymentRepository.GetById(id);
            if (existingPayment == null)
            {
                return NotFound();
            }

            _paymentRepository.Update(payment);
            return RedirectToAction(nameof(GetAllPayments));
        }
        public IActionResult DeletePayment(int id)
        {
            var payment = _paymentRepository.GetById(id);

            if (payment == null)
            {
                return NotFound();
            }

            _paymentRepository.Delete(id);
            return View(payment);
            // return RedirectToAction(nameof(GetAllPayments));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
