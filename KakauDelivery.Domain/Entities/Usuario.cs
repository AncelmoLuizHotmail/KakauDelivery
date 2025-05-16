namespace KakauDelivery.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario() { }

        public Usuario(string email, string senhaHash, string perfil, Cliente? cliente)
        {
            Email = email;
            SenhaHash = senhaHash;
            Perfil = perfil;
            IdCliente = cliente?.Id;
        }

        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public string Perfil { get; private set; }
        public int? IdCliente { get; private set; }

        public virtual Cliente? Cliente { get; private set; }

        public void SetSenha(string senha) => SenhaHash = senha;
    }
}
