using ConversorDeMoeda.Entities;
using System.Collections.Generic;

namespace ConversorDeMoeda.Interfaces
{
    public interface IMoedaRepository
    {
        Moeda ObterMoeda(string moeda);
        IList<Moeda> ObterTodasMoedas();
    }
}
