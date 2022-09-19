using System;
using System.Linq;
using PagamentoContexto.Domain.Entities;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Domain.ValueObjects;
using Xunit;

namespace PagamentoContexto.Tests.Entities;

public class AlunoTest
{
    public Aluno GerarNovoAluno()
    {
        var nome = new NomeCompleto("Gabriel", "Furlan");
        var documento = new Documento("192389172", TipoDocumento.CPF);
        var email = new Email("gabrielfurlan@email.com");

        return new Aluno(nome, documento, email);  
    }

    [Fact]
    public void Deve_retornar_erro_quando_tentar_colocar_mais_de_uma_assinatura_valida()
    {
        var aluno = GerarNovoAluno();

        var assinatura1 = new Assinatura(DateTime.Now.AddDays(30));
        var assinatura2 = new Assinatura(DateTime.Now.AddDays(30));

        aluno.AdicionarAssinatura(assinatura1);
        aluno.AdicionarAssinatura(assinatura2);

        Assert.False(aluno.Validar(aluno));
    }

    [Fact]
    public void Deve_retornar_sucesso_quando_ja_conter_uma_assinatura_invalida_e_adicionar_uma_nova_assinatura_valida()
    {
        var aluno = GerarNovoAluno();

        var assinatura = new Assinatura(DateTime.Now.AddDays(30));
        aluno.AdicionarAssinatura(assinatura);
        Assert.False(aluno.Validar(aluno));

        var novaAssinatura = new Assinatura(DateTime.Now.AddDays(30));
        aluno.AdicionarAssinatura(novaAssinatura);
        Assert.False(aluno.Validar(aluno));
    }
}