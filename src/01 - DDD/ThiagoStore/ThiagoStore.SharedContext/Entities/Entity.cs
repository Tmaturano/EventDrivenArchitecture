using System;

namespace ThiagoStore.SharedContext.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
