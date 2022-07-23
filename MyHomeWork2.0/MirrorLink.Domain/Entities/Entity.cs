using System;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Business.Entities
{
    public class Entity : IEntity, IEquatable<IEntity>
    {
        public int Id { get; set; }

        public bool Equals(IEntity? other)
        {
            return other != null && Id == other.Id && GetType() == other.GetType();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as IEntity);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}