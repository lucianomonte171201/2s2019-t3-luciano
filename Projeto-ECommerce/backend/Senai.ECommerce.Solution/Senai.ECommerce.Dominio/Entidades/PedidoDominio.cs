using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Senai.ECommerce.Dominio.Entidades
{
    [Table("Pedidos")]
    public class PedidoDominio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("DescricaoPedido", TypeName = "Text")]
        public string DescricaoPedido { get; set; }

        [Column("Turma", TypeName = "Text")]
        [Required]
        public string Turma { get; set; }

        [Column("Email", TypeName = "varchar(100)")]
        [Required]
        public string Email { get; set; }

        [Column("Telefone", TypeName = "varchar(100)")]
        [Required]
        public string Telefone { get; set; }

        [Column("Ativo", TypeName = "bit")]
        public bool Ativo { get; set; }
    }
}
