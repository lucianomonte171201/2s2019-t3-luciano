using Senai.ECommerce.Dominio.Entidades;
using Senai.ECommerce.Dominio.Interfaces;
using Senai.ECommerce.Infra.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Senai.ECommerce.Infra.Data.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        public PedidoDominio AlterarStatus(int id)
        {
            try
            {
                var pedido = BuscarPorId(id);

                if (pedido != null)
                {
                    pedido.Ativo = !pedido.Ativo;
                    Editar(pedido);
                    return pedido;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PedidoDominio BuscarPorId(int id)
        {
            try
            {
                using (ECommerceContext ctx = new ECommerceContext())
                {
                    return ctx.Pedidos.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PedidoDominio Cadastrar(PedidoDominio pedido)
        {
            try
            {
                using (ECommerceContext ctx = new ECommerceContext())
                {
                    ctx.Pedidos.Add(pedido);
                    ctx.SaveChanges();
                    return pedido;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PedidoDominio Editar(PedidoDominio pedido)
        {
            try
            {
                using (ECommerceContext ctx = new ECommerceContext())
                {
                    ctx.Entry<PedidoDominio>(pedido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    ctx.SaveChanges();
                    return pedido;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExcluirPedido(int id)
        {
            try
            {
                using (ECommerceContext ctx = new ECommerceContext())
                {
                    var pedido = BuscarPorId(id);

                    ctx.Entry<PedidoDominio>(pedido).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PedidoDominio> Listar()
        {
            try
            {
                using (ECommerceContext ctx = new ECommerceContext())
                {
                    return ctx.Pedidos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
