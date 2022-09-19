using Flunt.Validations;
using Flunt.Notifications;
using PagamentoContexto.Shared.ValueObjects;

namespace PagamentoContexto.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string rua, string bairro, string numero, string cEP, string cidade, string uF, string complemento)
        {
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            CEP = cEP;
            Cidade = cidade;
            UF = uF;
            Complemento = complemento;

            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNullOrEmpty(rua, "Endereco.Rua")
            .IsNullOrEmpty(bairro, "Endereco.Bairro")
            .IsNullOrEmpty(numero, "Endereco.Numero")
            .IsNullOrEmpty(cEP, "Endereco.CEP")
            .IsNullOrEmpty(cidade, "Endereco.Cidade")
            .IsNullOrEmpty(uF, "Endereco.UF")
            .IsNullOrEmpty(complemento, "Endereco.Complemento")
            );
        }

        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string Complemento { get; private set; }
        
    }
}