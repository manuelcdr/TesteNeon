using System;
using System.Collections.Generic;
using System.Text;

namespace ConversorDeMoeda.Entities
{
    public class Conversao
    {
        public Conversao(Moeda origem, Moeda destino, decimal valorOrigem, decimal valorDestino)
        {
            Origem = origem;
            Destino = destino;
            ValorOrigem = valorOrigem;
            ValorDestino = valorDestino;
        }

        public Moeda Origem { get; set; }
        public Moeda Destino { get; set; }
        public decimal ValorOrigem { get; set; }
        public decimal ValorDestino { get; set; }
    }
}
