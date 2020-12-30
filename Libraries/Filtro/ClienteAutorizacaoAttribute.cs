using System;
using LVirt.Libraries.Login;
using LVirt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace LVirt.Libraries.Filtro
{
    //Tipos de flitros:
    //- Autorizacao
    //- Recurso
    //- Acao
    //- Excecao
    //- Resultado
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {

        LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));
            Cliente cliente = _loginCliente.GetCliente();

            if (cliente == null)
            {
                context.Result = new ContentResult() { Content = "Acesso negado." };
            }

        }
    }
}
