using HotelManagementSystem.Models;
using HotelManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IRepository<Reservations> _reservationRepository;

        public ReservationsController(IRepository<Reservations> reservationRepository)
        {
            _reservationRepository = reservationRepository;

        }
        public IActionResult GetAllReservations()
        {
            var reservations = _reservationRepository.GetAll();
            return View(reservations);
        }

        public IActionResult AddReservation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddReservation(Reservations reservation)
        {
            if (reservation == null)
            {
                Console.WriteLine("Reservation alanı boş olamaz");
            }
            _reservationRepository.Add(reservation);
            return RedirectToAction(nameof(GetAllReservations));
        }
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _reservationRepository.GetById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            _reservationRepository.Delete(id);
            return View(reservation);
            // return RedirectToAction(nameof(GetAllPayments));
        }
        public IActionResult UpdateReservation(int id)
        {
            var reservations = _reservationRepository.GetById(id);
            if (reservations == null)
            {
                return NotFound();
            }
            return View(reservations);
        }
        [HttpPost]
        public IActionResult UpdateReservation(int id, Reservations reservations)
        {
            if (reservations == null || id != reservations.CustomerId)
            {
                Console.WriteLine("Geçersiz işlem");
            }
            var existingReservation = _reservationRepository.GetById(id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            _reservationRepository.Update(reservations);
            return RedirectToAction(nameof(GetAllReservations));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
