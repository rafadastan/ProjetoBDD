using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTestProjectBDD.Models;
using XUnitTestProjectBDD.TestSteps;

namespace XUnitTestProjectBDD.Scenarios
{
    public class AcessoUsuarioTest
    {
        //atributos
        private const string urlCadastro = "https://lojaexemplod.lojablindada.com/customer/account/create/";
        private const string urlAutenticacao = "https://lojaexemplod.lojablindada.com/customer/account/login/";

        [Fact] //Método de teste
        public void AcessoUsuario_LojaDeLivros()
        {
            //instanciando a classe TestSteps
            var steps = new AcessoUsuarioSteps();

            #region Cadastro do usuário

            //Acessar a página de cadastro de usuário
            steps.AcessarPaginaDeCadastro(urlCadastro);

            //cadastrar um usuario
            var modelCadastro = new UsuarioCadastroModel
            {
                Nome = "Raphael",
                Sobrenome = "Augusto",
                Email = $"raphael.augusto{new Random().Next(999999)}@gmail.com",
                Senha = $"@Admin{new Random().Next(9999)}"
            };

            steps.PreencherFormularioDeCadastro(modelCadastro);
            var resultCadastro = steps.RealizarCadastro();

            //critério de teste
            resultCadastro.Should().Contain("Obrigado por se registrar com LOJA EXEMPLO de Livros");

            //fechar a sessão do usuário
            steps.SairDoSistema();

            #endregion

            #region Autenticação do usuário

            //acessar a página de autenticação
            steps.AcessarPaginaDeAutenticacao(urlAutenticacao);

            //autenticar o usuário
            var modelAutenticacao = new UsuarioAutenticacaoModel
            {
                Email = modelCadastro.Email,
                Senha = modelCadastro.Senha
            };

            steps.PreencherFormularioDeAutenticacao(modelAutenticacao);
            var resultAutenticacao = steps.RealizarAutenticacao();

            resultAutenticacao.Should().Contain($"Bem-vindo, {modelCadastro.Nome} {modelCadastro.Sobrenome}!");

            steps.SairDoSistema();

            #endregion
        }
    }
}
