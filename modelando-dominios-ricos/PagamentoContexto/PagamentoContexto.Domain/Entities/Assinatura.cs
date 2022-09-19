
namespace PagamentoContexto.Domain.Entities
{
    public class Assinatura
    {

        IList<Pagamento> _pagamentos;
        public Assinatura(DateTime? dataExpiracao)
        {
            DateTime dataAtual = DateTime.Now;
            DataGeracao = dataAtual;
            UltimaAtualizacao = dataAtual;
            DataExpiracao = dataExpiracao;
            _pagamentos = new List<Pagamento>();

        }

        public DateTime DataGeracao { get; private set; }
        public DateTime UltimaAtualizacao { get; private set; }
        public DateTime? DataExpiracao { get; private set; }
        public IReadOnlyCollection<Pagamento> Pagamentos { get {return _pagamentos.ToArray(); } }
        public bool Ativo { get; private set; }

        public void AdicionarPagamento(Pagamento pagamento)
            => _pagamentos.Add(pagamento);

        public void Ativar(Assinatura assinatura)
        {
            assinatura.Ativo = true;
            assinatura.UltimaAtualizacao = DateTime.Now;
        }

        public void Inativar(Assinatura assinatura)
        {
            assinatura.Ativo = false;
            assinatura.UltimaAtualizacao = DateTime.Now;
        }
    }
}