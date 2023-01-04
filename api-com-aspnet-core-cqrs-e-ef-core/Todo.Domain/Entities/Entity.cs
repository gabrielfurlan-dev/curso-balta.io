using System;
using Flunt;
using Flunt.Notifications;

namespace ToDo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity> //Notifiable<Notification>,
    {
        protected Entity()
        => Id = Guid.NewGuid();

        public Guid Id { get; private set; }

        public bool Equals(Entity? other)
            => Id == other?.Id;
    }
}