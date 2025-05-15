namespace KakauDelivery.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente() { }

        public Cliente(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Pedidos = [];
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public List<Pedido> Pedidos { get; private set; }
    }

}
