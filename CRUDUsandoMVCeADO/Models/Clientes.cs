using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsandoMVCeADO.Models
{
    public class Clientes
    {
        [DisplayName("Cliente")]
        public int CodigoCliente { get; set; }
        [Required(ErrorMessage = "O nome é requerido")]
        public string NomeFantasia { get; set; }
    }
}