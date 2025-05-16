using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop.Cliente;
using KakauDelivery.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace KakauDelivery.Application.Interop.Usuario
{
    public class UsuarioInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O Email informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Required]
        public PerfilUsuarioEnum Perfil { get; set; }

        public ClienteInputModel? Cliente { get; set; }

        public void SetPassword(string password, IPasswordHasher passwordHasher)
        {
            Senha = passwordHasher.HashPassword(password);
        }
    }
}
