using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Taller.Domain.Enums;

namespace Taller.Domain.Entities
{
    public class Account
    {
        [JsonPropertyName("TipoCuenta")]
        public AccountType Type { get; set; }
        [Key]
        public Guid Id { get; set; }
        [JsonPropertyName("estado")]
        public bool State { get; set; }
        [JsonPropertyName("NumeroCuenta")]
        public string Number { get; set; }
        [JsonPropertyName("SaldoIncial")]
        public decimal Balance { get; set; }

        public Guid ClientId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(ClientId))]
        public virtual Client ClientNav { get; set; }
                
    }
}
