using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Enums;

namespace Taller.Domain.Entities
{
    public class Movement
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public MovementType MovementType { get; set; }

        public decimal Value { get; set; }

        public decimal ValueBalance { get; set; }
    }
}
