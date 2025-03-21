﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<User> userManager, IMapper mapper) 
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AddDataViewModel> GetUserAddDataViewModelAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found");

            return _mapper.Map<AddDataViewModel>(user);
        }

        public async Task<DetailViewModel> GetUserDetailsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found");

            return _mapper.Map<DetailViewModel>(user);
        }

        public async Task<UserEditViewModel> GetUserEditViewModelAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found");

            return new UserEditViewModel
            {
                Email = user.Email,
            };
        }

        public async Task UpdateUserDataAsync(string userId, AddDataViewModel addDataViewModel)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found");

            _mapper.Map(addDataViewModel, user);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to update user data");
            }
        }

        public async Task<bool> UpdateUserEmailAndPasswordAsync(string userId, UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found");

            
            if(user.Email != userEditViewModel.Email)
            {
                var userEmail = await _userManager.FindByEmailAsync(userEditViewModel.Email);
                if (userEmail != null)
                {
                    throw new ArgumentException("User with this email already exists");
                }
                user.Email = userEditViewModel.Email;
            }
            
            var passwordChek = await _userManager.CheckPasswordAsync(user, userEditViewModel.OldPassword);
            if (!passwordChek)
            {
                throw new ArgumentException("Old password is not correct");
            }
            var passwordResult = await _userManager.ChangePasswordAsync(user, userEditViewModel.OldPassword, userEditViewModel.Password);
            if (!passwordResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to change password");
            }
            return true;
        }
    }
}
