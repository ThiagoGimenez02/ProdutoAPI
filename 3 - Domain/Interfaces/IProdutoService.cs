using Domain.Models;
using System.Collections.Generic;
namespace Domain.Interfaces
{
    public interface IProdutoService        
    {
        void LimparBase();
        void GerarBase(int qtdProdutos);
        List<Produto> GetProdutos();
        List<ProdutoResumo> GetProdutoResumos();
    }
}
