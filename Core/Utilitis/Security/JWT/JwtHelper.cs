﻿using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilitis.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilitis.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } // appsettings.json bilgileri okuyor.TokenOptions gibi bilgiler
        private TokenOptions _tokenOptions; // appsettings.json den okuduğumuz değerleri bu sınıfa  atacağız. Kullanabilmek için
        private DateTime _accessTokenExpiration; // token kaç dakika geçerli olacak onun süresi
        public JwtHelper(IConfiguration configuration) //appsettings.json concractır.
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //json to class
            //benim degerlerim Configuration içerisinde ki TokenOptions GetSection almak.
            //  TokenOptions içerisine map lıyor.
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//ne zaman bitecek.10 dakika 
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //güvenlik anahtarı oluşturacak.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//kullanılacak şifreleme sistemi ve anahtarı veriyoruz
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//atanacak claimleri oluştutacağız
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(//bilgileri oluşturuyoruz.
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),//Claimler önemli oyüzden bir methot yapılmış.
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>(); //var olan bir nesneye yeni  methotlar eklenebiliyor.
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }


    }
}
