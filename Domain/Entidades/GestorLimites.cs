using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    [DynamoDBTable("gestor-limites-dynamo")]
    public class GestorLimites
    {
        [DynamoDBHashKey("pk")]
        public required string Documento { get; set; }
        [DynamoDBRangeKey("sk")]
        public required string NumConta { get; set; }
        [DynamoDBProperty]
        public required string NumAgencia { get; set; }
        [DynamoDBProperty]
        public required decimal LimiteTransacao { get; set; }
    }
}
