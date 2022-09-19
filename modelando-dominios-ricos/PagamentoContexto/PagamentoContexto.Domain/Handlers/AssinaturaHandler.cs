using Flunt.Notifications;
using PagamentoContexto.Domain.Commands;
using PagamentoContexto.Domain.Entities;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Domain.Repositories;
using PagamentoContexto.Domain.Services;
using PagamentoContexto.Domain.ValueObjects;
using PagamentoContexto.Shared.Commands;
using PagamentoContexto.Shared.Handlers;

namespace PagamentoContexto.Domain.Handlers
{
    public class AssinaturaHandler : Notifiable<Notification>, IHandler<CriarAssinaturaPagamentoComBoletoCommand>
    {
        private readonly IAlunoRepository _repository;
        private readonly IEmailService _emailService;

        public AssinaturaHandler(IAlunoRepository repository, IEmailService emailService){
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CriarAssinaturaPagamentoComBoletoCommand command)
        {
            //Fail validation
            command.Validar();
            if(!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            //Verificar se documento está cadastrado
            if (_repository.ExisteEmail(command.Email))
                AddNotification("Email", "Este email já está em uso");

            //Verificar se Email já esta cadastrado
            if (_repository.ExisteDocumento(command.DocumentoPagamento))
                AddNotification("Documento", "Este CPF já está em uso");

            //Gerar os Value Objects (VOs)
            var documento = new Documento(command.DocumentoPagamento, TipoDocumento.CNPJ);
            var nome = new NomeCompleto(command.PrimeiroNome, command.SegundoNome);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Rua, command.Bairro, command.Numero, command.CEP, command.Cidade, command.UF, command.Complemento);

            //gerar entidades
            var aluno = new Aluno(nome, documento,email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var documentoPagamento = new Documento(command.DocumentoPagamento, command.TipoDocumentoPagamento);
            var pagamento = new BoletoPagamento(command.CodigoDeBarras,
                                                command.NumeroBoleto,
                                                command.DataDePagamento,
                                                command.DataDeExpiracao,
                                                command.Total,
                                                command.TotalPago,
                                                command.Emitente,
                                                documentoPagamento,
                                                endereco,
                                                email);

            //Relacionamentos
            aluno.AdicionarAssinatura(assinatura);
            assinatura.AdicionarPagamento(pagamento);

            //agrupar validacoes
            AddNotifications(documento, nome, email, endereco, aluno, documentoPagamento, pagamento, assinatura);
            
            //Checar as notificações
            if(!command.IsValid)
                return new CommandResult(false, "Não foi possível registrar sua assinatura.");

            //Salvar as informacoes
            _repository.CriarAssinatura(aluno);

            //Enviar email de boas vindas
            _emailService.EnviarEmail(aluno.NomeCompleto.ToString(), aluno.Email.Endereco,  "Bem vindo ao gigante!", "Sua assinatura Vasco Football Club (PREMIUM) foi criada com sucesso!");

            //Retornar informacoes
            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }
    
        public ICommandResult Handle(CriarAssinaturaPagamentoComPayPalCommand command)
        {
            //Verificar se documento está cadastrado
            if (_repository.ExisteEmail(command.Email))
                AddNotification("Email", "Este email já está em uso");

            //Verificar se Email já esta cadastrado
            if (_repository.ExisteDocumento(command.DocumentoPagamento))
                AddNotification("Documento", "Este CPF já está em uso");

            //Gerar os Value Objects (VOs)
            var documento = new Documento(command.DocumentoPagamento, TipoDocumento.CNPJ);
            var nome = new NomeCompleto(command.PrimeiroNome, command.SegundoNome);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Rua, command.Bairro, command.Numero, command.CEP, command.Cidade, command.UF, command.Complemento);

            //gerar entidades
            var aluno = new Aluno(nome, documento,email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var documentoPagamento = new Documento(command.DocumentoPagamento, command.TipoDocumentoPagamento);
            var pagamento = new PayPalPagamento(command.CodigoDeTransacao,
                                                command.DataDePagamento,
                                                command.DataDeExpiracao,
                                                command.Total,
                                                command.TotalPago,
                                                command.Emitente,
                                                documentoPagamento,
                                                endereco,
                                                email);

            //Relacionamentos
            aluno.AdicionarAssinatura(assinatura);
            assinatura.AdicionarPagamento(pagamento);

            //Aplicar validacoes
            AddNotifications(documento, nome, email, endereco, aluno, documentoPagamento, pagamento, assinatura);

            //Salvar as informacoes
            _repository.CriarAssinatura(aluno);

            //Enviar email de boas vindas
            _emailService.EnviarEmail(aluno.NomeCompleto.ToString(), aluno.Email.Endereco,  "Bem vindo ao grande!", "Sua assinatura Vasco Football Club (PREMIUM) foi criada com sucesso!");

            //Retornar informacoes
            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }
    }
}