using System.Collections.Generic;
using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeCostumerRepository : IClienteRepository
    {
        public Cliente ObterCliente(string documento)
        {
            if (documento == "1234567891011")
                return new Cliente("Brune Wayne", "batman@batEmail.com");

            return null;
        }
    }
}