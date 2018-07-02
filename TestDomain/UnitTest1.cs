using ConversorDeMoeda.Entities;
using ConversorDeMoeda.Interfaces;
using Data;
using Microsoft.AspNetCore.Mvc;
using Moedas.Controllers;
using Moq;
using System;
using Xunit;

namespace TestDomain
{
    public class UnitTest1
    {
        public MoedasController moedasController { get; set; }

        public UnitTest1()
        {
            var mockService = new Mock<IConversorMoeda>();
            var mockRepository = new MoedaRepository();

            moedasController = new MoedasController(
                mockRepository,
                mockService.Object);
        }

        // AAA => Arrange, Act, Assert
        [Fact(DisplayName = "Converter uma moeda com sucesso")]
        public void MoedasController_RegistrarEvento_RetornarComSucesso()
        {
            // Arrange
            // controller 

            // Act
            var result = moedasController.Conversao("BRL", "USD", 1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        // AAA => Arrange, Act, Assert
        [Fact(DisplayName = "Obter Moedas")]
        public void MoedasController_ObterListaMoedas_RetornarComSucesso()
        {
            // Arrange
            // controller 

            // Act
            var result = moedasController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        // AAA => Arrange, Act, Assert
        [Fact(DisplayName = "Obter Moeda")]
        public void MoedasController_ObterMoeda_RetornarComSucesso()
        {
            // Arrange
            // controller 

            // Act
            var result = moedasController.Get("USD");

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        // AAA => Arrange, Act, Assert
        [Fact(DisplayName = "Conversão de moeda com sucesso")]
        public void Moeda_Conversao_ValorCorreto()
        {
            // Arrange
            var moeda1 = new Moeda("United States", "USD", 1);
            var moeda2 = new Moeda("Brazilian", "BRL", 3.5m);

            // Act
            var result = moeda1.ObterConversao(moeda2, 1);

            // Assert
            Assert.True(result.ValorOrigem == 1);
            Assert.True(result.ValorDestino == 3.5m);
        }

        // AAA => Arrange, Act, Assert
        [Fact(DisplayName = "Conversão de moeda com sucesso 2")]
        public void Moeda_Conversao_ValorCorreto2()
        {
            // Arrange
            var moeda1 = new Moeda("United States", "USD", 1);
            var moeda2 = new Moeda("Brazilian", "BRL", 3.5m);

            // Act
            var result = moeda1.ObterConversao(moeda2, 2);

            // Assert
            Assert.True(result.ValorOrigem == 2);
            Assert.True(result.ValorDestino == 7);
        }
    }
}
