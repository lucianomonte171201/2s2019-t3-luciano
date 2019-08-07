using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ECommerce.Dominio.Entidades;
using Senai.ECommerce.Dominio.Interfaces;
using Senai.ECommerce.Infra.Data.Repositorios;
using Senai.ECommerce.Servico.ViewModels;

namespace Senai.ECommerce.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedidoRepositorio _pedidoRepositorio;

        public PedidoController()
        {
            _pedidoRepositorio = new PedidoRepositorio();
        }

        [HttpPost]
        public IActionResult Post(PedidoViewModel pedido)
        {
            try
            {
                PedidoDominio pedidoNovo = new PedidoDominio()
                {
                    DescricaoPedido = pedido.DescricaoPedido,
                    Turma = pedido.Turma,
                    Email= pedido.Email,
                    Telefone = pedido.Telefone,
                    Ativo = pedido.Ativo
                };

                var pedidoRetorno = _pedidoRepositorio.Cadastrar(pedidoNovo);

                return Ok(pedidoRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_pedidoRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("listarativos")]
        public IActionResult ListarAtivos()
        {
            try
            {
                return Ok(_pedidoRepositorio.Listar().Where(x => x.Ativo));
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var pedido = _pedidoRepositorio.BuscarPorId(id);

                if (pedido == null)
                    return NotFound(new { mensagem = "Pedido não encontrado" });

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpPut("alterarstatus/{id}")]
        public IActionResult AlterarStatus(int id)
        {
            try
            {
                var pedido = _pedidoRepositorio.BuscarPorId(id);

                if (pedido == null)
                    return NotFound(new { mensagem = "Pedido não encontrado" });

                var pedidoRetorno = _pedidoRepositorio.AlterarStatus(id);

                return Ok(pedidoRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Editar(PedidoViewModel pedido, int id)
        {
            try
            {
                var pedidoExiste = _pedidoRepositorio.BuscarPorId(id);

                if (pedidoExiste == null)
                    return NotFound(new { mensagem = "Pedido não encontrado" });

                PedidoDominio pedidoAlterar = new PedidoDominio()
                {
                    Id = pedido.Id,
                    DescricaoPedido = pedido.DescricaoPedido,
                    Turma = pedido.Turma,
                    Email = pedido.Email,
                    Telefone = pedido.Telefone,
                    Ativo = pedido.Ativo
                };

                _pedidoRepositorio.Editar(pedidoAlterar);

                return Ok(pedidoAlterar);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }
    }
}