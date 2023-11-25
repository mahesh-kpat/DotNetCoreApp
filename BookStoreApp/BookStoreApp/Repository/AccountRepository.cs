using BookStoreApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUpUserModel.FirstName,
                LastName = signUpUserModel.LastName,
                Email = signUpUserModel.Email,
                UserName = signUpUserModel.Email
            };

            var result = await _userManager.CreateAsync(user, signUpUserModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
          var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }


        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
