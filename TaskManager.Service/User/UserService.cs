using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Service.Repository;
using TaskManager.Data.Models;
using TaskManager.Data.DTOs;
using System.Linq;

namespace TaskManager.Service.User
{
    public class UserService : IUserService
    {
        private IRepository _repo;

        public UserService(IRepository repo)
        {
            _repo = repo;   
        }

        public async System.Threading.Tasks.Task CreateUser(string username, string password)
        {
            await _repo.AddAsync(new Data.Models.User() { Username = username, Password = password});
            await _repo.SaveChangesAsync();
        }

        public UserDTO[] GetAllUsers()
        {
            return _repo.All<Data.Models.User>()
                .Select(x => new UserDTO
                {
                    Username = x.Username,
                    Password = x.Password
                })
                .ToArray();
        }

        public UserDTO GetUser(string username)
        {
            var user = _repo.All<Data.Models.User>().FirstOrDefault(u => u.Username == username);

            if(user == null)
            {
                throw new InvalidOperationException("User does not exist");
            }

            return new UserDTO() { Username = user.Username, Password = user.Password};
        }
    }
}
