﻿using AutoMapper;
using backend.Data;
using backend.Dto;
using backend.Mdl;
using backend.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper mapper;
        public UsuarioController(UserManager<IdentityUser> userManger, IMapper mapper)
        {
            _userManager = userManger;
            this.mapper = mapper;
        }

        [HttpPost(Name = "Usuario")]
        public async Task<IActionResult> Create(UsuarioRequestViewModel usuario)
        {
            try
            {
                IdentityUser? usuarioJaExistente = await _userManager.FindByEmailAsync(usuario.Email);
                if (usuarioJaExistente != null)
                {
                    return BadRequest("Já existe um usuário com esse email.");
                }
                
                var validadorSenha = new PasswordValidator<IdentityUser>();
                var resultadoValidacaoSenha = await validadorSenha.ValidateAsync(_userManager, null, usuario.Senha);
                
                if (!resultadoValidacaoSenha.Succeeded)
                {
                    return BadRequest(resultadoValidacaoSenha);
                }
                
                if (ModelState.IsValid)
                {
                    IdentityUser novoUsuario = mapper.Map<IdentityUser>(usuario);
                    //IdentityUser novoUsuario = new IdentityUser()
                    //{
                    //    UserName = usuario.Nome,
                    //    Email = usuario.Email,
                    //};

                    IdentityResult resultado = await _userManager.CreateAsync(novoUsuario, usuario.Senha);
                    UsuarioResponseViewModel resposta = mapper.Map<UsuarioResponseViewModel>(novoUsuario);
                    //UsuarioResponseViewModel resposta = new UsuarioResponseViewModel()
                    //{
                    //    Id = novoUsuario.Id,
                    //    Nome = novoUsuario.UserName,
                    //    Email = novoUsuario.Email
                    //};
                    return Ok(resposta);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
