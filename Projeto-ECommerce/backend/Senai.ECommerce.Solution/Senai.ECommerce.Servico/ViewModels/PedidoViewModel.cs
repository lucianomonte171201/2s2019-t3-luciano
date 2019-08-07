using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Senai.ECommerce.Servico.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }

        public string DescricaoPedido { get; set; }

        [Required(ErrorMessage = "Informe a turma")]
        public string Turma { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o telefone")]
        public string Telefone { get; set; }

        public bool Ativo { get; set; }
    }
}
