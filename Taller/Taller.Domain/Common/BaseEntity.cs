using System;

namespace Taller.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}