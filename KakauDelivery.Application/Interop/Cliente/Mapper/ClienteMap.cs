namespace KakauDelivery.Application.Interop.Cliente.Mapper
{
    public static class ClienteMap
    {
        public static Domain.Entities.Cliente InputModelForEntity(this ClienteInputModel inputModel)
        {
            return new Domain.Entities.Cliente(inputModel.IdUsuario, inputModel.Nome, inputModel.Email, inputModel.Telefone);
        }

        public static ClienteViewModel EntityForViewModel(this Domain.Entities.Cliente entity)
        {
            return new ClienteViewModel()
            {
                Id = entity.Id,
                IdUsuario = entity.IdUsuario,
                Nome = entity.Nome,
                Email = entity.Email,
                Telefone = entity.Telefone
            };
        }

        public static IEnumerable<ClienteViewModel> EntityForViewModelList(this IEnumerable<Domain.Entities.Cliente> entityList)
        {
            return (from entity in entityList
                    select new ClienteViewModel
                    {
                        Id = entity.Id,
                        IdUsuario = entity.IdUsuario,
                        Nome = entity.Nome,
                        Email = entity.Email,
                        Telefone = entity.Telefone

                    }).ToList();
        }
    }
}
