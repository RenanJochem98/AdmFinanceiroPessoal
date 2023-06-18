using AutoMapper;
using backend.Data;
using backend.Dto;
using backend.Mdl;
using backend.Svc;
using backend.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;

namespace backend.Controllers
{
    /// <summary>
    /// Teste de descrição para swagger
    /// </summary>
    [ApiController, Authorize]
    [Route("[controller]")]
    public class UsuarioController : GenericController<Usuario>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper mapper;
        public override DbSet<Usuario> Repositorio => DataContext.Users;

        public UsuarioController(UserManager<IdentityUser> userManger, IMapper mapper)
        {
            _userManager = userManger;
            this.mapper = mapper;
        }


        [HttpPost(Name = "Usuario"), AllowAnonymous]
        public async Task<IActionResult> Create(UsuarioRequestViewModel usuario)
        {
            try
            {
                IdentityUser? usuarioJaExistente = await _userManager.FindByEmailAsync(_userManager.NormalizeEmail(usuario.Email));
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
                    if (resultado.Succeeded)
                    {
                        UsuarioResponseViewModel resposta = mapper.Map<UsuarioResponseViewModel>(novoUsuario);
                        //UsuarioResponseViewModel resposta = new UsuarioResponseViewModel()
                        //{
                        //    Id = novoUsuario.Id,
                        //    Nome = novoUsuario.UserName,
                        //    Email = novoUsuario.Email
                        //};
                        return Ok(resposta);

                    }
                    return BadRequest(resultado);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> Login(UsuarioLoginRequestViewModel usuarioLogin)
        {
            IdentityUser? usuario = await _userManager.FindByEmailAsync(_userManager.NormalizeEmail(usuarioLogin.Email));
            if (usuario == null)
            {
                return NotFound();
            }
            if (await _userManager.CheckPasswordAsync(usuario, usuarioLogin.Senha))
            {
                UsuarioLoginResponseViewModel resultado = new UsuarioLoginResponseViewModel()
                {
                    Token = SvcToken.GerarToken(usuario),
                    RefreshToken = SvcToken.GerarRefreshToken(usuario),
                    Usuario = mapper.Map<UsuarioResponseViewModel>(usuario)
                };
                return Ok(resultado);
            }
            return Unauthorized("Usuário ou senha inválido.");

        }

    }
}
