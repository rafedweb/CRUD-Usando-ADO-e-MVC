using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsandoMVCeADO.Models
{
    public class Pessoa
    {
        [DisplayName("Pessoa")]
        public int Id { get; set; }
        [Required(ErrorMessage ="O nome é requerido")]
        public string nome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
    }
}