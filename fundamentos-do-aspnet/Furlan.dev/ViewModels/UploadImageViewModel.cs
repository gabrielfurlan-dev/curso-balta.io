using System.ComponentModel.DataAnnotations;

namespace Furlan.dev.ViewModels
{
    public class UploadImageViewModel
    {
        [Required(ErrorMessage = "Imagen inválida")]
        public string Base64Image { get; set; }
    }
}