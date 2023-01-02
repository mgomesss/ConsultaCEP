using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using ConsultaCEP.Models;
using System.Linq.Expressions;

namespace ConsultaCEP.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(string cep)
        {
            if (cep != null )
                if (cep != "")
                {
                    var result = await Cep(cep);

                    try
                    {
                        ViewBag.cep = result.cep;
                        ViewBag.logradouro = result.logradouro;
                        ViewBag.bairro = result.bairro;
                        ViewBag.localidade = result.localidade;
                        ViewBag.uf = result.uf;
                    }
                    catch
                    {
                        
                    }
                    
                }
            return View();
        }

        static async Task<ConsultaCep> Cep(string cep)
        {
            // Cria um novo cliente HttpClient e define a URL da API do ViaCEP
            var client = new HttpClient();
            var url = "https://viacep.com.br/ws/" + cep + "/json/";

            // Faz uma solicitação GET à URL e armazena a resposta em uma variável
            var response = await client.GetAsync(url);


            // Verifica se a solicitação foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                // Lê o conteúdo da resposta e o armazena em uma string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserializa a string de resposta para um objeto usando o Newtonsoft.Json
                var result = JsonConvert.DeserializeObject<ConsultaCep>(responseContent);

                return result;
            }
            else
            {
                return null;
            }
        }

    }
}