using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public string Perfil { get; private set; }
        public int IdCliente { get; private set; }

        public virtual Cliente Cliente { get; private set; }
    }
}
