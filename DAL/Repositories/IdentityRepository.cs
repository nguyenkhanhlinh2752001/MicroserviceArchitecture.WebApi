using Microservices.Models.DTOs;
using Microservices.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DAL.Repositories
{
    public class IdentityRepository
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public IdentityRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ResponseVM> PostRegistration(RegisterDTO model)
        {
            var existsUser = await _userManager.FindByNameAsync(model.UserName);
            if (existsUser != null)
            {
                return new ResponseVM
                {
                    Message = "User already exists",
                    IsSuccess = false
                };
            }
            var identityUser = new IdentityUser
            {
                UserName = model.UserName,
            };
            var rs = await _userManager.CreateAsync(identityUser, model.Password);
            if (rs.Succeeded)
                return new ResponseVM
                {
                    Message = "Register successfully",
                    IsSuccess = true
                };
            return new ResponseVM
            {
                Message = "Register failed",
                IsSuccess = false,
                Errors = rs.Errors.Select(e => e.Description)
            };
        }

        public async Task<ResponseVM> PostLogin(LoginDTO model)
        {
            var existsUser = await _userManager.FindByNameAsync(model.UserName);
            if (existsUser == null)
                return new ResponseVM
                {
                    Message = "User not exists",
                    IsSuccess = false
                };
            var signin = await _signInManager.PasswordSignInAsync(existsUser, model.Password, false, false);
            if (signin.Succeeded)
                return new ResponseVM
                {
                    Message = "Login successfully",
                    IsSuccess = true
                };
            return new ResponseVM
            {
                Message = "Login failed",
                IsSuccess = false
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ResponseVM> ResetPassword(ResetPasswordDTO model)
        {
            var existsUser = await _userManager.FindByNameAsync(model.UserName);
            if (existsUser == null)
                return new ResponseVM
                {
                    Message = "User not exists",
                    IsSuccess = false
                };
            var reset = await _userManager.ResetPasswordAsync(existsUser, model.Token, model.Password);
            if (reset.Succeeded)
                return new ResponseVM
                {
                    Message = "Reset password successfully",
                    IsSuccess = true
                };
            return new ResponseVM
            {
                Message = "Reset password failed",
                IsSuccess = false,
                Errors = reset.Errors.Select(e => e.Description)
            };
        }

        public async Task<string> GetPasswordResetToken(string username)
        {
            var existsUser = await _userManager.FindByNameAsync(username);
            if (existsUser == null)
            {
                return string.Empty;
            }
            return await _userManager.GeneratePasswordResetTokenAsync(existsUser);
        }

        public async Task<IdentityUser> GetUserByToken(ClaimsPrincipal principle)
        {
            return await _userManager.GetUserAsync(principle);
        }

        public async Task<string> GetJWTToken(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var principle = await _signInManager.CreateUserPrincipalAsync(user);
            var token = new JwtSecurityTokenHandler().CreateToken(new SecurityTokenDescriptor()
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("super_duper_secret_key")), SecurityAlgorithms.HmacSha256),
                Expires = DateTime.UtcNow.AddDays(1),
                Subject = (ClaimsIdentity)principle.Identity,
                Audience = "http://ahmadmozaffar.net",
                Issuer = "http://ahmadmozaffar.net"
            });
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}