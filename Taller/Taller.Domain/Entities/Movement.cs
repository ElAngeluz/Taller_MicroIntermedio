using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taller.Domain.Enums;

namespace Taller.Domain.Entities
{
    public class Movement
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public MovementType MovementType { get; set; }

        [Column(TypeName = "decimal(10,5)")]
        public decimal Value { get; set; }

        [Column(TypeName = "decimal(10,5)")]
        public decimal ValueBalance { get; set; }
    }
}
