using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
           throw new NotImplementedException();
        }
        public UserDto Add(UserDtoInsert user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new ApplicationException("User email already exists");
            }

            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client"
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            var userDto = new UserDto
            {
                UserId = newUser.UserId,
                Name = newUser.Name,
                Email = newUser.Email,
                UserType = newUser.UserType
            };

            return userDto;
        }

        public UserDto GetUserByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers()
        {
           throw new NotImplementedException();
        }

    }
}