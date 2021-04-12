using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Interfaces.Repository;
using System.Linq;

namespace ProdutoAPI.Repository.DataBase_Produto
{
    public class DB_Produto : DbContext, IProdutoRepository         // pega o contexto a ser usado
    {

        public DB_Produto(DbContextOptions<DB_Produto> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        public void GerarBase(List<Produto> Lista_produtos)
        {
            Produtos.AddRange(Lista_produtos);          // salva a lista de modelos recebida pelo IProdutoRepository 
            SaveChanges();
        }

        public List<ProdutoResumo> GetProdutoResumos()
        {
            List<ProdutoResumo> produtoResumosLista = new();

            foreach (Produto produto in Produtos.OrderBy(x => x.Nome).ToList())
            {
                if (produtoResumosLista.FirstOrDefault(x => x.Nome == produto.Nome) == null)        // pesquisa no banco os registros agrupados por produto, trazendo a soma das
                {                                                                                   // quantidades e a media de valunit
                    produtoResumosLista.Add(new ProdutoResumo()
                    {
                        Nome = produto.Nome,
                        Media = Math.Round((from p in Produtos
                                 where p.Nome == produto.Nome
                                 select p.VALUNIT).Average(), 2),
                        Quantidade = (from p in Produtos
                                      where p.Nome == produto.Nome
                                      select p.QTD).Sum()
                    });
                }
            }
            return produtoResumosLista;
        }

        public List<Produto> GetProdutos()
        {
                return Produtos.ToList();       // pesquisa todos os registros no banco
        }

        public void LimparBase()
        {
            Produtos.RemoveRange(Produtos.ToList());    // apaga todos os registros no banco
            SaveChanges();                              // salva as mudanças no banco
        }
    }
}
