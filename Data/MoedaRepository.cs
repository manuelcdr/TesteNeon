using ConversorDeMoeda.Entities;
using ConversorDeMoeda.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace Data
{
    public class MoedaRepository : IMoedaRepository
    {
        private HttpClient client = new HttpClient();
        private List<Moeda> Moedas = new List<Moeda>();
        private string ACCESS_KEY = "edc911a252414848b3751205e1f58115";

        public MoedaRepository()
        {
            Inicializar();
        }

        public Moeda ObterMoeda(string moeda)
        {
            var resultado = Moedas.SingleOrDefault(x => x.Nome == moeda || x.Cifra == moeda);
            return resultado;
        }

        public IList<Moeda> ObterTodasMoedas()
        {
            return Moedas;
        }

        private void Inicializar()
        {
            client.BaseAddress = new Uri("http://apilayer.net/api/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var responseList = client.GetAsync($"list?access_key={ACCESS_KEY}").Result;
            var responseLive = client.GetAsync($"live?access_key={ACCESS_KEY}&source=USD&format=1").Result;

            if (responseList.IsSuccessStatusCode && responseLive.IsSuccessStatusCode)
            {
                var listResult = responseList.Content.ReadAsStringAsync().Result;
                var jMoedas = JsonConvert.DeserializeXNode(listResult, "root");
                var currencies = jMoedas.Descendants().Single(x => x.Name.LocalName == "currencies").Descendants();

                var liveResult = responseLive.Content.ReadAsStringAsync().Result;
                var jValores = JsonConvert.DeserializeXNode(liveResult, "root");
                var quotes = jValores.Descendants().Single(x => x.Name.LocalName == "quotes").Descendants();

                foreach (var jMoeda in currencies)
                {
                    var nome = jMoeda.Value;
                    var cifra = jMoeda.Name.LocalName;

                    var stringValor = quotes.Single(x => x.Name.LocalName == $"USD{cifra}").Value.Replace(".",",");
                    var pesoDolar = Convert.ToDecimal(stringValor);

                    Moedas.Add(new Moeda(nome, cifra, pesoDolar));
                }
            }
        }
    }
}
