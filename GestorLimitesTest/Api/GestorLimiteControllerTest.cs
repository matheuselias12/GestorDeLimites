using Application.Service;
using Application.Service.Interface;
using AutoFixture;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Controllers;

namespace GestorLimitesTest.Api
{
    public class GestorLimiteControllerTest
    {
        private readonly Mock<ILogger<GestorLimiteController>> _logger;
        private readonly Mock<IGestorLimitesService> _gestorLimitesService;
        private readonly GestorLimiteController _gestorLimiteController;
        public GestorLimiteControllerTest()
        {
            _logger = new Mock<ILogger<GestorLimiteController>>();
            _gestorLimitesService = new Mock<IGestorLimitesService>();
            _gestorLimiteController = new GestorLimiteController(_logger.Object, _gestorLimitesService.Object);

        }

        [Fact]
        public async void CriaDadosDeLimites_RetornaStatus200()
        {
            //Arrange
            var obj = new Fixture().Create<GestorLimites>();

            //Act
            var result = _gestorLimiteController.CadastrarLimites(obj).Result;

            //Assert
            result.Equals(200);
        }


        [Fact]
        public async void AtualizarDadosDeLimites_DeveRetornaStatus200()
        {
            //Arrange
            var obj = new Fixture().Create<GestorLimites>();

            //Act
            var result = _gestorLimiteController.AtualizarLimites(obj).Result;

            //Assert
            result.Equals(200);
        }

        [Fact]
        public async void DeletarDadosDeLimites_DeveRetornaStatus200()
        {
            //Arrange
            var obj = new Fixture().Create<GestorLimites>();
            string doc = obj.Documento;
            string numconta = obj.NumConta;
            _gestorLimitesService.Setup(c => c.ObterRegistros(doc, numconta)).ReturnsAsync(obj);

            //Act
            var result = _gestorLimiteController.RemoverRegistro(doc, numconta);

            //Assert
            result.Equals(200);
        }

        [Fact]
        public async void ObterDadosDeLimites_DeveRetornaDadosDeLimites()
        {
            //Arrange
            var obj = new Fixture().Create<GestorLimites>();
            string doc = obj.Documento;
            string numconta = obj.NumConta;

            _gestorLimitesService.Setup(c => c.ObterRegistros(doc, numconta)).ReturnsAsync(obj);

            //Act
            var result = _gestorLimiteController.ObterRegistros(doc, numconta).Result;

            //Assert
            result.Equals(result);
        }
        [Fact]
        public async void EnviarTrasacaoDeLimites_DeveRetornaDadosDeLimites()
        {
            //Arrange
            var obj = new Fixture().Create<DadosTransacao>();

            //Act
            var result = _gestorLimiteController.EnviarTrasacao(obj).Result;

            //Assert
            result.Equals(result);
        }
    }
}
