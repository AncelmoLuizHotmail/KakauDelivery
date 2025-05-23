﻿namespace KakauDelivery.Application.Interop.Produto.Mapper
{
    public static class ProdutoMap
    {
        public static Domain.Entities.Produto InputModelForEntity(this ProdutoInputModel inputModel)
        {
            return new Domain.Entities.Produto(inputModel.Descricao, inputModel.Preco, inputModel.TipoProduto);
        }
        public static Domain.Entities.Produto ViewModelForEntity(this ProdutoViewModel inputModel)
        {
            return new Domain.Entities.Produto(inputModel.Descricao, inputModel.Preco, inputModel.TipoProduto);
        }
        public static ProdutoViewModel EntityForViewModel(this Domain.Entities.Produto entity)
        {
            return new ProdutoViewModel()
            {
                Id = entity.Id,
                Descricao = entity.Descricao,
                Preco = entity.Preco,
                TipoProduto = entity.TipoProduto
            };
        }
    }
}
