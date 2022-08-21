﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Taller.Domain.Entities
{
    [Table("cliente")]
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }

        [JsonPropertyName("Clave")]
        public string Password { get; set; }
        public bool State { get; set; }
        public string PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public virtual Person PersonNav { get; set; }
    }
}