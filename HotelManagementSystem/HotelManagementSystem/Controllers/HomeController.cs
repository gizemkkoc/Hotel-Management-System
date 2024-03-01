using HotelManagementSystem.Models;
using HotelManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelManagementSystem.Controllers
{
    public class HomeController : Controller
    {
       // private readonly IRepository<HotelRooms> _hotelRoomRepository;
      //  private readonly IRepository<Payments> _paymentRepository;
       // private readonly IRepository<Customers> _customerRepository;
        private readonly IRepository<Reservations> _reservationRepository;

        //public HomeController(
        //    IRepository<HotelRooms> hotelRoomRepository,
        //    IRepository<Payments> paymentRepository,
        //    IRepository<Customers> customerRepository,
        //    IRepository<Reservations> reservationRepository)
        //{
        //    _hotelRoomRepository = hotelRoomRepository;
        //    _paymentRepository = paymentRepository;
        //    _customerRepository = customerRepository;
        //    _reservationRepository = reservationRepository;
        //}        
        public IActionResult Index()
        {
            return View();
        }

       
      
      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}