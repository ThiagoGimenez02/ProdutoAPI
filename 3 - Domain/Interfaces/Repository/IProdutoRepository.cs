using Domain.Models;
using System.Collections.Generic;
namespace Domain.Interfaces.Repository
{
    public interface IProdutoRepository     
    {
        void LimparBase();
        void GerarBase(List<Produto> produtos);
        List<Produto> GetProdutos();
        List<ProdutoResumo> GetProdutoResumos();
    }
}
