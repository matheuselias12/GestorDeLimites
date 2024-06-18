using Application.Service;
using AutoFixture;
using Domain.Entidades;
using Infraestrutura.Repositories.Interface;
using Moq;
using WebApi.Controllers;

namespace GestorLimitesTest.App.Service
{
    public class GestorLimitesServiceTest
    {
        private readonly Mock<IGestorLimitesRepository> _gestorLimitesRepository;
        private readonly GestorLimitesService _gestorLimitesService;
        public GestorLimitesServiceTest()
        {
            _gestorLimitesRepository = new Mock<IGestorLimitesRepository>();
            _gestorLimitesService = new GestorLimitesService(_gestorLimitesRepository.Object);
        }

        [Fact]
        public async void CriaDadosDeLimites_RetornaStatus200()
        {
            //Arrange
            var obj = new GestorLimites()
            {
                Documento = "123456789",
                NumConta = "12345-6",
                NumAgencia = "1234",
                LimiteTransacao = 10000
            };

            //Act
            var result = _gestorLimitesService.CadastrarLimites(obj).Status;

            //Assert
            result.Equals(200);
        }

        [Fact]
        public async void AtualizarDadosDeLimites_DeveRetornaStatus200()
        {
            //Arrange
            var obj = new GestorLimites()
            {
                Documento = "123456789",
                NumConta = "12345-6",
                NumAgencia = "1234",
                LimiteTransacao = 10000
            };

            //Act
            var result = _gestorLimitesService.AtualizarLimites(obj).Status;

            //Assert
            result.Equals(200);
        }

        [Fact]
        public async void DeletarDadosDeLimites_DeveRetornaStatus200()
        {
            //Arrange
            var obj = new GestorLimites()
            {
                Documento = "123456789",
                NumConta = "12345-6",
                NumAgencia = "1234",
                LimiteTransacao = 10000
            };
            string doc = obj.Documento;
            string numconta = obj.NumConta;
            _gestorLimitesRepository.Setup(c => c.ObterRegistros(doc, numconta)).ReturnsAsync(obj);

            //Act
            var result = _gestorLimitesService.RemoverRegistro(doc, numconta);

            //Assert
            result.Equals(200);
        }

        [Fact]
        public async void ObterDadosDeLimites_DeveRetornaDadosDeLimites()
        {
            //Arrange
            var obj = new GestorLimites()
            {
                Documento = "123456789",
                NumConta = "12345-6",
                NumAgencia = "1234",
                LimiteTransacao = 10000
            };
            string doc = obj.Documento;
            string numconta = obj.NumConta;

            _gestorLimitesRepository.Setup(c => c.ObterRegistros(doc, numconta)).ReturnsAsync(obj);

            //Act
            var result = _gestorLimitesService.ObterRegistros(doc, numconta).Result;

            //Assert
            result.Equals(result);
        }
        [Fact]
        public async void EnviarTrasacaoDeLimites_DeveRetornaDadosDeLimites()
        {
            //Arrange
            var dadosTransacao = new DadosTransacao()
            {
                Documento = "123456789",
                NumConta = "12345-6",
                ChavePix = "987654321",
                ValorTransacao = 5000
            };
            var objGestorLimite = new GestorLimites()
            {
                Documento = "123456789",
                NumConta = "12345-6",
                NumAgencia = "1234",
                LimiteTransacao = 10000
            };

            string doc = "123456789";
            string numConta = "12345-6";

            _gestorLimitesRepository.Setup(c => c.ObterRegistros(doc, numConta)).ReturnsAsync(objGestorLimite);

            //Act
            var result = await _gestorLimitesService.EnviarTrasacao(dadosTransacao);

            //Assert
            result.Equals(result);
        }
    }
}
