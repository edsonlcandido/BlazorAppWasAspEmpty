using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWasAspEmpty.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyController : Controller
    {
        [HttpGet("index")]
        public string Get()
        {
            return "Hello from Daily controller";
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
