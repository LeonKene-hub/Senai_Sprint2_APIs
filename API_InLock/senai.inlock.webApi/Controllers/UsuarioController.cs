using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
{
    /// <summary>
    /// Controlador de Usuario, suas https e exucução de metodos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Construtor que define ponte para exucução dos metodos
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>lista de usuarios</returns>
        [HttpGet]
        [Authorize(Roles = "2")]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Domains.UsuarioDomain> listaUsuario = _usuarioRepository.ListarTodos();
                return Ok(listaUsuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">>informações do novo usuario</param>
        /// <returns>status code informando o resultado</returns>
        [HttpPost("Cadastro")]
        [Authorize(Roles = "2")]
        public IActionResult Cadastrar(UsuarioDomain usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um usuario atraves do seu ID
        /// </summary>
        /// <param name="id">ID buscado</param>
        /// <returns>status code informando o resultado</returns>
        [HttpDelete]
        [Authorize(Roles = "2")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Login, realiza autenticação do usuario
        /// </summary>
        /// <param name="usuario">usuario com email e senha</param>
        /// <returns>status code informando o resultado</returns>
        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("email ou senha invalidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    new Claim("Claim personalizada","Valor da Claim personalizada")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                        issuer: "senai.inlock.webApi",

                        audience: "senai.inlock.webApi",

                        claims: claims,

                        expires: DateTime.Now.AddMinutes(5),

                        signingCredentials: creds
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
