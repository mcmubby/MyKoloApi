using System;
using MyKoloApi.DTOs;
using MyKoloApi.Models;

namespace MyKoloApi.Services
{
    public interface IUserService
    {
        bool SignUp(RegisterUserDto user);
        
        LoggedInUserDto LogIn(LoginUserDto user);
    }
}