using ConversorDeMoeda.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Moedas.Controllers
{
    [Route("api/[controller]")]
    public class MoedasController : Controller
    {
        private readonly IMoedaRepository repository;
        private readonly IConversorMoeda conversorMoeda;

        public MoedasController(IMoedaRepository repository, IConversorMoeda conversorMoeda)
        {
            this.repository = repository;
            this.conversorMoeda = conversorMoeda;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var moedas = repository.ObterTodasMoedas();
            return Ok(moedas);
        }

        [HttpGet("{nome}")]
        public IActionResult Get(string nome)
        {
            var moeda = repository.ObterMoeda(nome);
            return Ok(moeda);
        }

        [HttpGet("conversao")]
        public IActionResult Conversao(string origem, string destino, decimal valor)
        {
            var conversao = conversorMoeda.Converter(origem, destino, valor);
            return Ok(conversao);
        }
    }
}
