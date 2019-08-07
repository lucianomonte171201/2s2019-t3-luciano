using Senai.ECommerce.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senai.ECommerce.Dominio.Interfaces
{
    public interface IPedidoRepositorio
    {
        PedidoDominio Cadastrar(PedidoDominio pedido);

        PedidoDominio Editar(PedidoDominio pedido);

        PedidoDominio AlterarStatus(int id);

        PedidoDominio BuscarPorId(int id);

        bool ExcluirPedido(int id);

        List<PedidoDominio> Listar();
    }
}
