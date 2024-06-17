using Application.Service.Interface;
using Domain.Entidades;
using Infraestrutura.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class GestorLimitesService : IGestorLimitesService
    {
        private readonly IGestorLimitesRepository _gestorLimitesRepository;

        public GestorLimitesService(IGestorLimitesRepository gestorLimitesRepository)
        {
            _gestorLimitesRepository = gestorLimitesRepository;
        }
        public async Task AtualizarLimites(GestorLimites gestorLimite)
        {
            var obj = await _gestorLimitesRepository.ObterRegistros(gestorLimite.Documento, gestorLimite.NumConta);
            obj.LimiteTransacao = gestorLimite.LimiteTransacao;
            await _gestorLimitesRepository.AtualizarLimites(obj);
        }

        public async Task CadastrarLimites(GestorLimites gestorLimite)
        {
            await _gestorLimitesRepository.CadastrarLimites(gestorLimite);
        }

        public async Task<GestorLimites> ObterRegistros(string documento, string numConta)
        {
            return await _gestorLimitesRepository.ObterRegistros(documento, numConta);
        }

        public async Task RemoverRegistro(string documento, string numConta)
        {
            await _gestorLimitesRepository.RemoverRegistro(documento, numConta);
        }
        public async Task<GestorLimites> EnviarTrasacao(DadosTransacao dadosTransacao)
        {
            var conta = await _gestorLimitesRepository.ObterRegistros(dadosTransacao.Documento, dadosTransacao.NumConta);

            if (conta is not null)
            {
                if (conta.LimiteTransacao < dadosTransacao.ValorTransacao)
                {
                    throw new InvalidOperationException($"Valor {dadosTransacao.ValorTransacao} excedeu o valor de limite transação.");
                }
            }
            else
            {
                throw new InvalidOperationException($"O número da conta não existe!");
            }

            conta.LimiteTransacao = conta.LimiteTransacao - dadosTransacao.ValorTransacao;

            await _gestorLimitesRepository.AtualizarLimites(conta);

            return conta;
        }
    }
}
