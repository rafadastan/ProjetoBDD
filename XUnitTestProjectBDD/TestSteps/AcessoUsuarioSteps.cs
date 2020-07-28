using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using XUnitTestProjectBDD.Contracts;
using XUnitTestProjectBDD.Models;

namespace XUnitTestProjectBDD.TestSteps
{
    public class AcessoUsuarioSteps : IAcessoUsuarioSteps
    {
        private IWebDriver webDriver;

        public void AcessarPaginaDeAutenticacao(string url)
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();

            webDriver.Navigate().GoToUrl(url);
        }

        public void AcessarPaginaDeCadastro(string url)
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();

            //acessar uma página web
            webDriver.Navigate().GoToUrl(url);
        }

        public void PreencherFormularioDeAutenticacao(UsuarioAutenticacaoModel model)
        {
            //preenchendo o campo email
            var email = webDriver.FindElement(By.CssSelector("#email"));
            email.Clear();
            email.SendKeys(model.Email);

            //preenchendo o campo senha
            var senha = webDriver.FindElement(By.CssSelector("#pass"));
            senha.Clear();
            senha.SendKeys(model.Senha);
        }

        public void PreencherFormularioDeCadastro(UsuarioCadastroModel model)
        {
            var nome = webDriver.FindElement(By.CssSelector("#firstname"));
            nome.Clear();
            nome.SendKeys(model.Nome);

            var sobrenome = webDriver.FindElement(By.CssSelector("#lastname"));
            sobrenome.Clear();
            sobrenome.SendKeys(model.Sobrenome);

            var email = webDriver.FindElement(By.CssSelector("#email_address"));
            email.Clear();
            email.SendKeys(model.Email);

            var senha = webDriver.FindElement(By.CssSelector("#password"));
            senha.Clear();
            senha.SendKeys(model.Senha);

            var confirmaSenha = webDriver.FindElement(By.CssSelector("#confirmation"));
            confirmaSenha.Clear();
            confirmaSenha.SendKeys(model.Senha);
        }

        public string RealizarAutenticacao()
        {
            //capturar o botão do formulário para submit dos dados
            var botao = webDriver.FindElement(By.CssSelector("#send2"));

            //verificar se o botão está habilitado
            if (botao.Enabled)
            {
                botao.Click(); //clicando no botão
            }

            //ler a mensagem obtida após a autenticação do usuário
            var mensagem = webDriver.FindElement(By.CssSelector("body > div > div > div.header-container > div > div > p"));
            return mensagem.Text; //retornando a mensagem
        }

        public string RealizarCadastro()
        {
            //capturar o elemento HTML (botão de cadastro)
            var botao = webDriver.FindElement(By.CssSelector("#form-validate > div.buttons-set > button"));

            //verificar se o botão está habilitado
            if (botao.Enabled)
            {
                //clicar para realizar o cadastro
                botao.Click();
            }

            //ler a mensagem retornada pelo sistema
            var mensagem = webDriver.FindElement(By.CssSelector("body > div > div > div.main-container.col2-left-layout > div > div.col-main > div > div > ul > li > ul > li > span"));
            return mensagem.Text; //retornando o conteudo da mensagem..
        }

        public void SairDoSistema()
        {
            //buscar o link de logout (sair) na tela do sistema
            var botao = webDriver.FindElement(By.CssSelector("body > div > div > div.header-container > div > div > ul > li.last > a"));

            //verificar se o link esta visivel e habilitado
            if (botao.Displayed && botao.Enabled)
            {
                botao.Click();
            }

            //fechar o navegador
            webDriver.Close();
            webDriver.Quit();
        }
    }
}
