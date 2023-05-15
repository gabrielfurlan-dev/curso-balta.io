using Furlan.dev.Data;
using Furlan.dev.Models;
using Furlan.dev.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Furlan.dev.Controllers
{

    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpPost("v1/accounts/")]
        public async Task<IActionResult> Post(
            [FromBody] RegisterViewModel registerViewModel,
            [FromServices] BlogDataContext dataContext
        )
        {
            if (!ModelState.IsValid)
                return BadRequest("Model inválida");

            var user = new User
            {
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                Slug = registerViewModel.Email.Replace("@", "-")
                                              .Replace(".", "-")
            };

            var password = PasswordGenerator.Generate(length: 25, includeSpecialChars: true, upperCase: false);

            user.PasswordHash = PasswordHasher.Hash(password);

            try
            {
                await dataContext.Users.AddAsync(user);
                await dataContext.SaveChangesAsync();

                Console.WriteLine("passou aqui");

                return Ok(new { user = user.Email, password });

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(400, "05X99 - Este E-mail já está cadastrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"05X84 - Erro interno do servidor.{Environment.NewLine}{ex.Message}{Environment.NewLine}{ex.StackTrace}");
            }
        }

        [HttpPost("v1/accounts/login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginViewModel model,
            [FromServices] TokenService tokenService,
            [FromServices] BlogDataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetEnumerator()));

            var user = await context.Users.AsNoTracking()
                                          .Include(x => x.Roles)
                                          .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user is null)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            if (!PasswordHasher.Verify(user.PasswordHash, model.Password))
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            try
            {
                var token = tokenService.GenerateToken(user);
                return Ok(new ResultViewModel<string>(token, erros: null));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>(error: $"05X04 - Falha interna. {ex.Message}"));
            }

        }

        [HttpPost(template: "v1/login")]
        public IActionResult login([FromServices] TokenService service)
        {
            var token = service.GenerateToken(null);
            return Ok(token);
        }
    }
}