using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Shared.ValueObjects;

namespace PagamentoContexto.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
        public Documento(string numeroDocumento, TipoDocumento tipo)
        {
            NumeroDocumento = numeroDocumento;
            Tipo = tipo;
        }

        public string NumeroDocumento { get; set; }
        public TipoDocumento Tipo { get; set; }

        public bool Valido()
        {
            if(Tipo == TipoDocumento.CNPJ && NumeroDocumento.Length == 14)
                return true;

            if(Tipo == TipoDocumento.CPF && NumeroDocumento.Length == 11)
                return true;

            return false;
        }
    }
}