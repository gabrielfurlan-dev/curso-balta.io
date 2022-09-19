using Flunt.Notifications;
using PagamentoContexto.Domain.Commands;
using PagamentoContexto.Domain.Repositories;
using PagamentoContexto.Shared.Commands;
using PagamentoContexto.Shared.Handlers;

namespace PagamentoContexto.Domain.Handlers
{
    public class AssinaturaHandler : Notifiable<Notification>, IHandler<CriarAssinaturaPagamentoComBoletoCommand>
    {
        private readonly IAlunoRepository _repository;

        public AssinaturaHandler(IAlunoRepository repository){
            _repository = repository;
        }

        public ICommandResult Handle(CriarAssinaturaPagamentoComBoletoCommand command)
        {
            //Verificar se documento está cadastrado

            //Verificar se Email já esta cadastrado

            //Gerar os Value Objects (VOs)

            //gerar entidades

            //Aplicar validacoes

            //Salvar as informacoes

            //Enviar email de boas vindas

            //Retornar informacoes

            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }
    }
}