using HotelManagementSystem.Models;
using HotelManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly IRepository<HotelRooms> _hotelRoomRepository;
       
        public HotelRoomsController(IRepository<HotelRooms> hotelRoomRepository)
        {
            _hotelRoomRepository = hotelRoomRepository;
        }
        public IActionResult GetAllHotelRooms(int pageNumber, int pageSize = 10)
        {
            var rooms = _hotelRoomRepository.GetAll();
          //  var pagedList = rooms.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return View(rooms);
           // return PartialView("_RoomListPartial", pagedList);
        }
        public IActionResult AddHotelRoom()
        {
            // Ekleme sayfası
            return View();
        }
        [HttpPost]
        public IActionResult AddHotelRoom(HotelRooms hotelRoom)
        {
            if (hotelRoom == null)
            {
                Console.WriteLine("Oda bilgileri boş olamaz");
            }
            _hotelRoomRepository.Add(hotelRoom);
            return View();
           // return RedirectToAction(nameof(GetAllHotelRooms));

        }
        public IActionResult UpdateHotelRoom(int id)
        {
            var room = _hotelRoomRepository.GetById(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }
        [HttpPost]
        public IActionResult UpdateHotelRoom(int id, HotelRooms hotelRoom)
        {
            if (hotelRoom == null || id != hotelRoom.RoomId)
            {
                Console.WriteLine("Geçersiz işlem");
            }
            var existingRoom = _hotelRoomRepository.GetById(id);
            if (existingRoom == null)
            {
                return NotFound();
            }

            _hotelRoomRepository.Update(hotelRoom);
            return RedirectToAction(nameof(GetAllHotelRooms));
        }
        public IActionResult DeleteHotelRoom(int id)
        {
            var room = _hotelRoomRepository.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            _hotelRoomRepository.Delete(id);
            return View(room);
            //RedirectToAction(nameof(GetAllHotelRooms));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
