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
    [Table("persona")]
    public class Person
    {
        [JsonPropertyName("Nombre")]
        public string Name { get; set; }
        [JsonPropertyName("Genero")]
        public Gender Gender { get; set; }

        [JsonPropertyName("Edad")]
        public string YearsOld { get; set; }

        [Key]
        [JsonPropertyName("Identificacion")]
        public string Identification { get; set; }

        [JsonPropertyName("Direccion")]
        public string Address { get; set; }
        [JsonPropertyName("Telefono")]
        public string Phone { get; set; }

        public Client ClientNav { get; set; }
    }
}
