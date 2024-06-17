using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories.Interface
{
    public interface IGestorLimitesRepository
    {
        Task CadastrarLimites(GestorLimites gestorLimite);
        Task AtualizarLimites(GestorLimites gestorLimite);
        Task<GestorLimites> ObterRegistros(string documento, string numConta);
        Task RemoverRegistro(string documento, string numConta);
    }
}
