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
    public class PersonDTO
    {
        [JsonPropertyName("Nombre")]
        [StringLength(100)]
        public string Name { get; set; }

        [JsonPropertyName("Genero")]
        public GenderType Gender { get; set; }

        [JsonPropertyName("Edad")]
        public uint YearsOld { get; set; }

        [Key]
        [JsonPropertyName("Identificacion")]
        [StringLength(15)]
        public string Identification { get; set; }

        [JsonPropertyName("Direccion")]
        [StringLength(100)]
        public string Address { get; set; }

        [JsonPropertyName("Telefono")]
        [StringLength(25)]
        public string Phone { get; set; }
    }
}
