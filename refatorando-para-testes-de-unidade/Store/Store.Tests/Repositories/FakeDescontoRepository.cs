using System;
using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeDescontoRepository : IDescontoRepository
    {
        public Desconto Obter(string codigo)
        {
            if (codigo == "12345678")
            return new Desconto(10, DateTime.Now.AddDays(5));

            if(codigo == "11111111")
            return new Desconto(10, DateTime.Now.AddDays(-5));

            return null;
        }
    }
}