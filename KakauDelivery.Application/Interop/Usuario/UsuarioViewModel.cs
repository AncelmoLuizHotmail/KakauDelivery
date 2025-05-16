using KakauDelivery.Application.Interop.Cliente;

namespace KakauDelivery.Application.Interop.Usuario
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
      
        public virtual ClienteViewModel? Cliente { get; set; }
    }
}
