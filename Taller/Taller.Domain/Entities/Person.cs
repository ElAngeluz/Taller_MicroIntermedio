using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Taller.Domain.Enums;

namespace Taller.Domain.Entities
{
    [Table("persona")]
    public class Person
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

        public Client ClientNav { get; set; }
    }
}
