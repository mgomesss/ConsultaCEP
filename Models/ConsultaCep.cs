using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaCEP.Models
{
    public class ConsultaCep
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
    }
}