using ConversorDeMoeda.Interfaces;

namespace ConversorDeMoeda.Services
{
    public class ConversorMoeda : IConversorMoeda
    {
        private readonly IMoedaRepository repository;

        public ConversorMoeda(IMoedaRepository repository)
        {
            this.repository = repository;
        }

        public decimal Converter(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var entidadeMoedaOrigem = repository.ObterMoeda(moedaOrigem);
            var entidadeMoedaDestino = repository.ObterMoeda(moedaDestino);
            var conversao = entidadeMoedaOrigem.ObterConversao(entidadeMoedaDestino, valor);
            return conversao.ValorDestino;
        }
    }
}
