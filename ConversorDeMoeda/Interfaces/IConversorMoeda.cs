using ConversorDeMoeda.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConversorDeMoeda.Interfaces
{
    public interface IConversorMoeda
    {
        decimal Converter(string moedaOrigem, string moedaDestino, decimal valor);
    }
}
