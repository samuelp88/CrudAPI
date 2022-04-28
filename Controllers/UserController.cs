using CrudAPI.Business.Abstract;
using CrudAPI.Data;
using CrudAPI.Data.Output;
using CrudAPI.Data.VO;
using CrudAPI.Models;
using CrudAPI.Repositories;
using CrudAPI.Services;
using CrudAPI.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }



        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<LoginOutput>> Login([FromQuery] string user, [FromQuery] string password)
        {
            if (user == null || password == null) 
                return BadRequest("User or password query params missing");
            
            var loginOutput = await _userBusiness.Login(user, password);
            if (loginOutput == null) 
                return BadRequest("Usuário ou senha inválidos");

            return Ok(loginOutput);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserVO>> Register([FromBody] UserVO userData)
        {
            if (userData == null)
                return BadRequest("Corpo inválido");

            try
            {
                var registerOutput = await _userBusiness.Register(userData);
                return Ok(registerOutput);

            }
            catch (ArgumentException e) when (e is ArgumentException)
            {
                return BadRequest("Gênero inválido");
            }
            catch (Exception)
            {
                return BadRequest("Nome de usuário já existe!");
            }
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";

    }
}
