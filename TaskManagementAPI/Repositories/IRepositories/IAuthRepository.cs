﻿using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Repositories.IRepositories
{
    public interface IAuthRepository
    {
        Task<User> Register(UserDTO userDTO);
        Task<string> Login(string username, string password);
    }
}
