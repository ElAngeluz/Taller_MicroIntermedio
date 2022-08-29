using System;
using System.ComponentModel.DataAnnotations;

namespace Taller.Application.DTOs.Client
{
    public class ClientRequestDTO : ClientBasicDTO
    {
        public Guid? ClientId { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
    }
}
