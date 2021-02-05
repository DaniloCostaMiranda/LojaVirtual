using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LVirt.Libraries.Filtro;
using LVirt.Libraries.Lang;
using LVirt.Models;
using LVirt.Models.Constants;
using LVirt.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LVirt.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index(int? pagina, string pesquisa)
        {
            IPagedList<Cliente> clientes = _clienteRepository.ObterTodosClientes(pagina, pesquisa);
            return View(clientes);
        }

        [ValidateHttpReferer]
        public IActionResult AtivarDesativar(int id)
        {
            Cliente cliente = _clienteRepository.ObterCliente(id);
            cliente.Situacao = (cliente.Situacao == SituacaoConstant.Ativo) ? cliente.Situacao = SituacaoConstant.Desativado : cliente.Situacao = SituacaoConstant.Ativo;

            _clienteRepository.Atualizar(cliente);

            TempData["MSG_S"] = Mensagem.MSG_S001;

            return RedirectToAction(nameof(Index));
        }
    }
}
