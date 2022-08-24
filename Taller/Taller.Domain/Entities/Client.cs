using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Taller.Domain.Entities
{
    [Table("cliente")]
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }

        [JsonPropertyName("Clave")]
        [StringLength(50)]
        public string Password { get; set; }

        [JsonPropertyName("Esatdo")]
        public bool State { get; set; }

        [JsonPropertyName("PersonaId")]
        public Guid PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public virtual Person PersonNav { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Account.ClientNav))]
        public ICollection<Account> AccountsNav { get; set; }
    }
}
