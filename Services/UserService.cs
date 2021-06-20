using System;
using System.Linq;
using MyKoloApi.Data;
using BCryptNet = BCrypt.Net.BCrypt;
using MyKoloApi.DTOs;
using MyKoloApi.Models;

namespace MyKoloApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public UserService(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public LoggedInUserDto LogIn(LoginUserDto user)
        {
            var registeredUser = _context.Users.SingleOrDefault(c => c.UserName == user.UserName);

            if (registeredUser == null || !BCryptNet.Verify(user.Password, registeredUser.Password) )
            {
                return null;
            }
            else
            {
                var token = _tokenService.GenerateToken(registeredUser);
                
                var response = new LoggedInUserDto{
                    Id = registeredUser.Id,
                    UserName = registeredUser.UserName,
                    Email = registeredUser.Email,
                    PhoneNumber = registeredUser.PhoneNumber,
                    JwtToken = token
                };

                return response;
            }


        }

        public bool SignUp(RegisterUserDto user)
        {
            var existingUser = _context.Users.Any(c => c.Email == user.Email || c.UserName == user.UserName);

            if (existingUser)
            {
                return false;
            }

            var newUser = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = BCryptNet.HashPassword(user.Password),
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }
    }
}