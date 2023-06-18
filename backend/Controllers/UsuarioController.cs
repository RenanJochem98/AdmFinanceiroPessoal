using AutoMapper;
using backend.Data;
using backend.Mdl;
using backend.Svc;
using backend.ViewModel.Usuario;
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
    public class UsuarioController : GenericController<UsuarioRequestViewModel, UsuarioResponseViewModel, Usuario>
    {
        private readonly UserManager<Usuario> _userManager;
        public override DbSet<Usuario> Repositorio => DataContext.Users;

        public UsuarioController(UserManager<Usuario> userManger, IMapper mapper) : base(mapper)
        {
            _userManager = userManger;
        }



        [AllowAnonymous]
        [HttpPost("/[controller]/async")]
        public async Task<IActionResult> Create(UsuarioRequestViewModel usuario)
        {
            try
            {
                Usuario? usuarioJaExistente = await _userManager.FindByEmailAsync(_userManager.NormalizeEmail(usuario.Email));
                if (usuarioJaExistente != null)
                {
                    return BadRequest("Já existe um usuário com esse email.");
                }

                var validadorSenha = new PasswordValidator<Usuario>();
                var resultadoValidacaoSenha = await validadorSenha.ValidateAsync(_userManager, null, usuario.Senha);

                if (!resultadoValidacaoSenha.Succeeded)
                {
                    return BadRequest(resultadoValidacaoSenha);
                }

                if (ModelState.IsValid)
                {
                    Usuario novoUsuario = mapper.Map<Usuario>(usuario);

                    IdentityResult resultado = await _userManager.CreateAsync(novoUsuario, usuario.Senha);
                    if (resultado.Succeeded)
                    {
                        UsuarioResponseViewModel resposta = mapper.Map<UsuarioResponseViewModel>(novoUsuario);
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
            Usuario? usuario = await _userManager.FindByEmailAsync(_userManager.NormalizeEmail(usuarioLogin.Email));
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
