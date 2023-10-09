using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWasAspEmpty.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyController : Controller
    {
        [HttpGet("index")]  
        public async Task<string> Get()
        {
            //get JSON from the url https://cors.ehtudo.app/https://api.cartola.globo.com/atletas/mercado
            


            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://cors.ehtudo.app/https://api.cartola.globo.com/atletas/mercado");
            //use response
            
            return response.ToString();
        }
        [HttpGet("getall")]
        public List<Shared.Models.Daily> GetAll()
        {
            return Shared.Models.DailyAccessRepository.GetAll().ToList();
        }

        [HttpGet("index2")]
        public Shared.Models.Daily Index2()
        {
            return new Shared.Models.Daily()
            {
                AnaliseCredito = "AnaliseCredito",
                Cliente = "Cliente",
                CRM = "CRM",
                Código = 1,
                DataAprovacao = System.DateTime.Now,
                DataDefinicao = System.DateTime.Now,
                DataEntregaPrevista = System.DateTime.Now,
                DataEntregaReal = System.DateTime.Now,
                Pendencia = "Pendencia",
                Produto = "Produto",
                Projeto_Aplicacao = "Projeto_Aplicacao",
                PV = "PV",
                Responsavel = "Responsavel",
                Rev = "1",
                Segmento = "Segmento",
                Status = "Status",
                Tipo = "Tipo"
            };
        }
    }
}
