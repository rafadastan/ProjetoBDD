using System;
using System.Collections.Generic;
using System.Text;
using XUnitTestProjectBDD.Models;

namespace XUnitTestProjectBDD.Contracts
{
    public interface IAcessoUsuarioSteps
    {
        #region Criação de conta de usuário
        void AcessarPaginaDeCadastro(string url);
        void PreencherFormularioDeCadastro(UsuarioCadastroModel model);
        string RealizarCadastro();
        #endregion

        #region Autenticar Usuário
        void AcessarPaginaDeAutenticacao(string url);
        void PreencherFormularioDeAutenticacao(UsuarioAutenticacaoModel model);
        string RealizarAutenticacao();
        #endregion

        #region Sair do Sistema
        void SairDoSistema();
        #endregion
    }
}
