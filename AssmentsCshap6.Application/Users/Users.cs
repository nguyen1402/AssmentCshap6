using AsmentCShap6.ViewModels.Common;
using AssmentCshap6.Data.Entities;
using AssmentCshap6.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssmentsCshap6.Application.Users
{
    public class Users : IUsers
    {
        private readonly UserManager<Student> _userManager;
        //private readonly SignInManager<Student> _signInManager;

        private readonly IConfiguration _config;
        private readonly IConfigurationSection _jwtSettings;
        public Users(UserManager<Student> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
            _jwtSettings = _config.GetSection("JwtSettings");
        }
        public async Task<ApiResult<string>> Authencate(Loginrequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return new ApiErrorResult<string>("Đăng nhập không được !");
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new ApiSuccessResult<string> { IsSuccessed = true, Token = token };
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings["securityKey"]);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private List<Claim> GetClaims(Student user)
        {
            var claims = new List<Claim>
             {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings["validIssuer"],
                audience: _jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }
        public async Task<ApiResult<bool>> Register(Registerequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Tài khoản người dùng đã tồn tại !");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Email người dùng đã tồn tại !");
            }

            user = new Student()
            {
                DBO = request.DBO,
                Email = request.Email,
                HovsTenDem = request.HovaTenDem,
                Ten = request.Ten,
                Sexs = request.Sexs,
                Diachi = request.Diachi,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng kí thất bại !");
        }
    }
}
