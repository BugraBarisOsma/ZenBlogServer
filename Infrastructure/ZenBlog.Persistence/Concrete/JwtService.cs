using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Users.Results;
using ZenBlog.Application.Options;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Persistence.Concrete
{
    public class JwtService(UserManager<AppUser> userManager, IOptions<JwtTokenOptions> options) : IJwtService
    {
        private readonly JwtTokenOptions _options = options.Value;
        public async Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result)
        {
            // oncelikle kullanici bilgilerini alalim , cunku token olustururken kullanicinin bilgilerine ihtiyacimiz var
            var user = await userManager.FindByIdAsync(result.Id.ToString());

            // simetrik bir security key olusturalim , bu key token olustururken kullanilacak ve tokenin guvenligini saglayacak
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_options.Key));
            // datetime ile tokenin ne zaman olusturuldugunu ve ne zaman gecersiz olacagini belirleyelim
            var dateTimeNow = DateTime.UtcNow;

            // burada tokenin icerisinde bulunacak claimleri olusturalim , claimler tokenin icerisinde kullanicinin bilgilerini tutacak
            // kendi claimlerimizi de olusturabiliriz , ornegin FullName claimi kullanicinin tam adini tutacak
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Name,result.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, result.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, result.Email),
                new Claim("FullName", string.Join(" " , result.FirstName , result.LastName))
            };

            //Tokena son halini verelim. burada tokenin issuerini , audienceini , claimlerini , ne zaman olusturuldugunu ve ne zaman gecersiz olacagini belirliyoruz
            JwtSecurityToken jwtSecurityToken = new(
                            issuer: _options.Issuer,
                            audience: _options.Audience,
                            claims: claims,
                            notBefore: dateTimeNow,
                            expires: dateTimeNow.AddMinutes(Double.Parse(_options.ExpireInMinutes)),
                            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                        );

            // Token handler ile tokeni yazalim , bu tokeni kullaniciya doncegiz
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            // Tokeni ve tokenin gecersiz olma zamanini donelim
            return new GetLoginQueryResult
            {
                Token = token,
                ExpirationTime = jwtSecurityToken.ValidTo
            };
        }
    }
}
