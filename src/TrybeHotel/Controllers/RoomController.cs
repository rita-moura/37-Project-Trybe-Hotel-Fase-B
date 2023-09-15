using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _repository;
        public RoomController(IRoomRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{HotelId}")]
        public IActionResult GetRoom(int HotelId){
            return Ok(_repository.GetRooms(HotelId));
        }

        [HttpPost]
        public IActionResult PostRoom([FromBody] Room room){
            return Created(nameof(GetRoom), _repository.AddRoom(room));
        }

        [HttpDelete("{RoomId}")]
        public IActionResult Delete(int RoomId)
        {
           _repository.DeleteRoom(RoomId);
            return NoContent();
        }
    }
}