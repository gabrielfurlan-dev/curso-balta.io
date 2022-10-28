using System.Linq.Expressions;
using Store.Domain.Entities;

namespace Store.Domain.Enuns
{
    public static class ProdutoQueries
    {
        public static Expression<Func<Produto, bool>> RetornarApenasProdutosAtivos()
            => x => x.Ativo;

        public static Expression<Func<Produto, bool>> RetornarApenasProdutosInativos()
            => x => !x.Ativo;
    }
}