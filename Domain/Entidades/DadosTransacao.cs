using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class DadosTransacao
    {
        public required string Documento { get; set; }
        public required string NumConta { get; set; }
        public required string ChavePix { get; set; }
        public required decimal ValorTransacao { get; set; }
    }
}
