using System;
using System.Collections.Generic;
using System.Text;

namespace ConversorDeMoeda.Entities
{
    public class Moeda
    {
        public Moeda(string nome, string cifra, decimal pesoDolar)
        {
            Nome = nome;
            Cifra = cifra;
            PesoDolar = pesoDolar;
        }

        public string Nome { get; set; }
        public string Cifra { get; set; }
        public decimal PesoDolar { get; set; }

        public Conversao ObterConversao(Moeda destino, decimal valor)
        {
            var valorEmDolar = valor / PesoDolar;
            var valorDestino = valorEmDolar * destino.PesoDolar;
            var conversao = new Conversao(this, destino, valor, valorDestino);
            return conversao;
        }
    }
}
