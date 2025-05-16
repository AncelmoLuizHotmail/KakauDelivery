using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario() { }

        public Usuario(string email, string senhaHash, PerfilUsuarioEnum perfil, Cliente? cliente)
        {
            Email = email;
            SenhaHash = senhaHash;
            Perfil = perfil;
            Cliente = cliente;
        }

        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public PerfilUsuarioEnum Perfil { get; private set; }
     

        public virtual Cliente? Cliente { get; private set; }

        public void SetSenha(string senha) => SenhaHash = senha;
    }
}
