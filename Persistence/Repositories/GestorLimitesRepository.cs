using Amazon.DynamoDBv2.DataModel;
using Domain.Entidades;
using Infraestrutura.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class GestorLimitesRepository : IGestorLimitesRepository
    {
        private readonly IDynamoDBContext _dynamoDbContext;
        public GestorLimitesRepository(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }
        public async Task AtualizarLimites(GestorLimites gestorLimite)
        {
            await _dynamoDbContext.SaveAsync(gestorLimite);
        }
        public async Task CadastrarLimites(GestorLimites gestorLimite)
        {
            await _dynamoDbContext.SaveAsync(gestorLimite);
        }
        public async Task<GestorLimites> ObterRegistros(string documento, string numConta)
        {
            var list = await _dynamoDbContext.QueryAsync<GestorLimites>(documento, Amazon.DynamoDBv2.DocumentModel.QueryOperator.Equal, new object[] { numConta }).GetRemainingAsync();
            return list.FirstOrDefault();
        }
        public async Task RemoverRegistro(string documento, string numConta)
        {
            await _dynamoDbContext.DeleteAsync<GestorLimites>(documento, numConta);
        }
    }
}
