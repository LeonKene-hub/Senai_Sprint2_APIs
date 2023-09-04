using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;
using WebAPI.Filmes.manha.Repositories;

namespace WebAPI.Filmes.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //********************************************** GET **********************************************

        /// <summary>
        /// Endpoint que aciona o metodo de cadastro
        /// </summary>
        /// <returns>Usuario que contem os atributos inseridos</returns>
        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("email ou senha incorreto");
                }

                //Caso encontre o usuario, prossegue para a criação do token

                //1º - Definir as informacoes(Clains) que serao fornecidos no token(payload)

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role,usuarioBuscado.Permissao.ToString()),

                    //existe a possibilidade de criar uma claim personalisada
                    new Claim("Claim personalizada","Valor da Claim Personalizada")
                };

                //2º - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                //3º - Definir as credencias do token(HEADEER)
                var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                //4º - Gerar token
                var token = new JwtSecurityToken
                    (
                        //emissor do token
                        issuer: "WebAPI.Filmes.manha", 

                        //destinatario do token
                        audience: "WebAPI.Filmes.manha",

                        //dados definidos nas claims(informacoes)
                        claims : claims,

                        //tempo de expriracao do token
                        expires: DateTime.Now.AddMinutes(5),

                        //credencias do token
                        signingCredentials: creds
                    );

                //5º - retornar o token criado
                return Ok(new 
                {
                   token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
                throw;
            }

        }
    }
}
