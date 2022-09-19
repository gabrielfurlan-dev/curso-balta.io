using Flunt.Notifications;
using Flunt.Validations;
using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Entities
{
    public class Aluno : Notifiable<Notification>
    {
        IList<Assinatura> _assinaturas;
        public Aluno(NomeCompleto nomeCompleto, Documento documento, Email email)
        {
            NomeCompleto = nomeCompleto;
            Documento = documento;
            Email = email;
            _assinaturas = new List<Assinatura>();
        }

        public NomeCompleto NomeCompleto { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinaturas.ToArray(); }  }

        public void AdicionarAssinatura(Assinatura novaAssinatura)
        {
            var temAssinaturaAtiva = false;

            foreach (var assinatura in _assinaturas)
                if (assinatura.Ativo)
                    temAssinaturaAtiva = true;


            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(temAssinaturaAtiva, "Aluno.Assinaturas", "Você já possui uma assinatura ativa.")
            .IsGreaterThan(0, novaAssinatura.Pagamentos.Count(), "Aluno.Assinaturas.Pagamento", "Esta assinatura não possui pagamentos"));
        }

        public bool Validar(Aluno aluno)
        => aluno.Assinaturas.Select(x => x.Ativo == true).Count() == 1 ? true : false;

    }
}