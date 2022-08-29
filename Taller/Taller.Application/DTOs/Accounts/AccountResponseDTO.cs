using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Taller.Domain.Enums;

namespace Taller.Application.DTOs.Accounts
{
    public class AccountResponseDTO
    {
        [JsonPropertyName("TipoCuenta")]
        public AccountType Type { get; set; }
        
        [JsonPropertyName("estado")]
        public bool State { get; set; }

        [JsonPropertyName("NumeroCuenta")]
        [StringLength(50)]
        public string Number { get; set; }

        [JsonPropertyName("SaldoIncial")]
        public decimal Balance { get; set; }

        [JsonPropertyName("Cliente")]
        public string ClientName { get; set; }
    }
}
