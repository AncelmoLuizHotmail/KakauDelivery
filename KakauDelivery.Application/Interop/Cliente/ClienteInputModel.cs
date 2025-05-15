using System.ComponentModel.DataAnnotations;

namespace KakauDelivery.Application.Interop.Cliente
{
    public class ClienteInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O Email informado não é válido.")]
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
