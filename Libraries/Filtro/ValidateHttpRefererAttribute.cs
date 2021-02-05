using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LVirt.Libraries.Filtro
{
    public class ValidateHttpRefererAttribute : Attribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Executado antes de passar pelo controlador

            string referer = context.HttpContext.Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(referer))
            {
                context.Result = new ContentResult() { Content = "Acesso Negado!" };
            }
            else
            {
                Uri uri = new Uri(referer);

                string hostReferer = uri.Host;

                string hostServidor = context.HttpContext.Request.Host.Host;

                if(hostReferer != hostServidor){
                    context.Result = new ContentResult() { Content = "Acesso negado!" };
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Executado apos passar pelo controlador

        }

       
    }
}
