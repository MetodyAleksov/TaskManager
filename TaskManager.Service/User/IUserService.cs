using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Data.DTOs;

namespace TaskManager.Service.User
{
    public interface IUserService
    {
        System.Threading.Tasks.Task CreateUser(string username, string password);
        UserDTO GetUser(string username);
        UserDTO[] GetAllUsers();
    }
}
