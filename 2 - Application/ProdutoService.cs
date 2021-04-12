using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Application
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository; 
        }

        public void GerarBase(int qtdProdutos)
        {
            List<Produto> listaProdutos = new();

            Random num_random = new();

            string[] nome_produto = { "Mouse", "KeyB", "PenD", "Fone", "TV", "Caixa", "NoteB", "Telef",
                                      "Robo", "Drone", "Avião", "Moto", "Carro", "Fonte", "Cabo"};

            for (int i = 0; i < qtdProdutos; i++)
            {
                int num_escolhido = num_random.Next(0, 14);

                listaProdutos.Add(                      // popula uma lista com modelos usando valores "Randomicos"
                new Produto
                {
                    Nome = nome_produto[num_escolhido],
                    QTD = num_random.Next(1, 27),
                    VALUNIT = Math.Round(num_random.NextDouble() * 199.99, 2)
                });
            }

            _produtoRepository.GerarBase(listaProdutos);   // Envia uma lista de modelos
        }                                                 

        public List<ProdutoResumo> GetProdutoResumos()
        {                                   
            return _produtoRepository.GetProdutoResumos(); // faz uma requisição da lista de produtos
        }                                                  // agrupados pelo nome

        public List<Produto> GetProdutos()
        {
            return _produtoRepository.GetProdutos();    // faz uma requisição da lista de produtos
        }                                               

        public void LimparBase()
        {
            _produtoRepository.LimparBase();       // Envia uma requisição de limpar o banco 
        }                                           
    } 
}
