using System.ComponentModel.DataAnnotations;

namespace Furlan.dev.ViewModels
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage = "O Nome é obrigatório.")]
        public string Name { get; set; }        

        [Required (ErrorMessage = "O E-mail é obrigatório.")]
        [EmailAddress (ErrorMessage = "O E-mail é inválido.")]
        public string Email { get; set; }        
        // public string Password { get; set; }        
    }
}