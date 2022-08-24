using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Taller.Domain.Enums;

namespace Taller.Application.DTOs
{
    public class ClientDTO
    {
        [JsonPropertyName("Nombre")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Key]
        [JsonPropertyName("Identificacion")]
        [StringLength(15)]
        [Required]
        public string Identification { get; set; }

        [JsonPropertyName("Direccion")]
        [StringLength(100)]
        public string Address { get; set; }

        [JsonPropertyName("Telefono")]
        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(50)]        
        public string Password { get; set; }

        [JsonPropertyName("Estado")]
        public bool ClientState { get; set; }
    }
}
