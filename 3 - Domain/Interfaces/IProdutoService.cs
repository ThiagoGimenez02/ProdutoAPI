using Domain.Models;
using System.Collections.Generic;
namespace Domain.Interfaces
{
    public interface IProdutoService        // Cria um "Contrato" entre o ProdutoController e ProdutoService
    {
        void LimparBase();
        void GerarBase(int qtdProdutos);
        List<Produto> GetProdutos();
        List<ProdutoResumo> GetProdutoResumos();
    }
}
