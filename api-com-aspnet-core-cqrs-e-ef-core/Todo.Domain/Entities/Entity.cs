using System;
using Flunt;
using Flunt.Notifications;

namespace Todo.Domain.Entities
{
    public abstract class Entity :  Notifiable<Notification>, IEquatable<Entity>
    {
        protected Entity()
        => Id = Guid.NewGuid();

        public Guid Id { get; private set; }

        public bool Equals(Entity? other)
            => Id == other?.Id;
    }
}