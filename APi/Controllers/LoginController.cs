﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModel;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]


    [Route("api/[controller]")]


    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }


        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {

            UsuariosDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login);


            if (usuarioBuscado == null)
            {

                return NotFound("E-mail ou senha inválidos");
            }


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };


            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: "InLock.WebApi",
                audience: "InLock.WebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );


            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
