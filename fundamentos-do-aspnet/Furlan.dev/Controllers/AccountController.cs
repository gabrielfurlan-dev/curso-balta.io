using System.Text.RegularExpressions;
using Furlan.dev.Data;
using Furlan.dev.Models;
using Furlan.dev.Service;
using Furlan.dev.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
            [FromServices] EmailService emailService,
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

                // if (emailService.Send(user.Name, user.Email, "Bem vindo ao Furlan.dev", $"Sua senha é {password}."))
                // {
                    return Ok(new { user = user.Email, password });
                    await dataContext.SaveChangesAsync();
                // }
                // else
                    return BadRequest(new { Error = "Não possível cadastrar o usuário. Falha ao enviar email de confirmação." });
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

        [Authorize]
        [HttpPost("v1/accounts/upload-image")]
        public async Task<IActionResult> UploadImage(
            [FromBody] UploadImageViewModel model,
            [FromServices] BlogDataContext context
        )
        {
            var filename = $"{Guid.NewGuid().ToString()}.jpg";
            var data = new Regex( @"^data:image\/[a-z]+;base64,").Replace(model.Base64Image, String.Empty);
            var bytes = Convert.FromBase64String(data);

            try
            {
                await System.IO.File.WriteAllBytesAsync($"wwwroot/images/{filename}", bytes);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>(error: "05X04 - Falha interna no servidor"));
            }

            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);

            if(user is null)
                return NotFound(new ResultViewModel<User>(error: "Usuário não encontrado"));

            user.Image = $"https://localhost:0000/images/{filename}";

            try
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>(error: "05X04 - Falha interna no servidor"));
            }

            return Ok(new ResultViewModel<string>(error: "Imagem alterada com sucesso."));
        }
    }
}