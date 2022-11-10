using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enuns;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProdutoQueriesTest
    {

        private IList<Produto> _produtos;

        public ProdutoQueriesTest()
        {
            _produtos = new List<Produto>();
            _produtos.Add(new Produto("Produto 001", 1m, true));
            _produtos.Add(new Produto("Produto 002", 2m, true));
            _produtos.Add(new Produto("Produto 003", 3m, true));
            _produtos.Add(new Produto("Produto 004", 4m, false));
            _produtos.Add(new Produto("Produto 005", 5m, false));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
        {
            var result = _produtos.AsQueryable().Where(ProdutoQueries.RetornarApenasProdutosAtivos());

            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_a_consulta_de_produtos_inativos_nao_deve_retornar_itens(){
            var produtos = new List<Produto>();

            var sut = produtos.AsQueryable().Where(ProdutoQueries.RetornarApenasProdutosAtivos());

            Assert.AreEqual(0, sut.Count()); 
        }

        [TestMethod]
        [TestCategory("domain")]
        public void Dado_a_consulta_com_produtos_ativos_e_inativos_deve_retornar_somente_os_ativos()
        {
            var sut = _produtos.AsQueryable().Where(ProdutoQueries.RetornarApenasProdutosAtivos());

            Assert.AreEqual(3, sut.Count());
        }

        [TestMethod]
        [TestCategory("domain")]
        public void Dado_a_consulta_com_produtos_ativos_e_inativos_deve_retornar_somente_os_inativos()
        {
            var sut = _produtos.AsQueryable().Where(ProdutoQueries.RetornarApenasProdutosInativos());

            Assert.AreEqual(2, sut.Count());
        }
    }
}