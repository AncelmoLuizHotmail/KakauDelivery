using KakauDelivery.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace KakauDelivery.Application.Interop.Pedido
{
    public class PedidoFilter
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public StatusPedidoEnum Status { get; set; }
    }
}
