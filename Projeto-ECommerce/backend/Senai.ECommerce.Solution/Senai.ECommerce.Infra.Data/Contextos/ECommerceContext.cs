using Microsoft.EntityFrameworkCore;
using Senai.ECommerce.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senai.ECommerce.Infra.Data.Contextos
{
    public class ECommerceContext : DbContext
    {
        public DbSet<PedidoDominio> Pedidos { get; set; }
    }
}
