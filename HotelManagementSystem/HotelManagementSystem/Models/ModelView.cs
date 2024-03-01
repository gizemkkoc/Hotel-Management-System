namespace HotelManagementSystem.Models
{
	public class ModelView
	{
		public HotelRooms SingleRoom { get; set; }
		public IEnumerable<HotelRooms> RoomList { get; set; }
	}
}
