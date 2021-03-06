﻿using System.Linq;
using Entities;
using Exceptions;
using ServiceInterfaces;
using TodoRepository.Interfaces;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        

        public void Register(string userName, string password, string email)
        {
            if (GetRegisteredUser() != null)
            {
                throw new TodoException("User has already registered");
            }
            _userRepository.Create(new User(userName, email, password));
        }

        public bool UnRegister()
        {
            if (GetRegisteredUser() == null)
            {
                return false;
            }
            _userRepository.Create(new User("", "", ""));
            return true;
        }

        public bool Logon(string userName, string password)
        {
            User user = GetRegisteredUser();
            if (user == null)
            {
                throw new TodoException("User not yet registered");
            }
            return user.Name == userName && user.MatchPassword(password);
        }

        public User GetRegisteredUser()
        {
            var user = GetUser();
            if (user == null || string.IsNullOrEmpty(user.Name))
            {
                return null;
            }
            return user;
        }

        public User GetUser()
        {
            return _userRepository.Entities.FirstOrDefault();
        }
    }
}
