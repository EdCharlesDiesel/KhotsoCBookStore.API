using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.DomainLayer
{
   
    public abstract class Entity<K>: IEntity<K>  where K: IEquatable<K>
    {  
        // 1.1 It is common to override the Object.Equals method of all
        // the DDD entities in such a way that two objects are considered equal whenever they
        // have the same primary keys. This is easily achieved by letting all the entities inherit
        // from an abstract Entity class
        public virtual K Id { get; protected set; }

        // 1.2 The IsTransient predicate returns true whenever the entity has been recently
        // created and hasn't been recorded in the permanent storage, so its primary key is still
        // undefined.
        public bool IsTransient()
        {
            return Object.Equals(Id, default(K));            
        }
        
        public override bool Equals(object obj)
        {
            return obj is Entity<K> entity &&
              Equals(entity); 
        }

        public bool Equals(IEntity<K> other)
        {
            if (other == null || 
                other.IsTransient() || this.IsTransient())
                return false;

            return Object.Equals(Id, other.Id);
        }

        // 1.3 In .NET, it is good practice that, whenever you override the
        // Object.Equals method of a class, you also override its Object.
        // GetHashCode method so that class instances can be efficiently
        // stored in data structures such as dictionaries and sets. That's why
        // the Entity class overrides it.
        int? _requestedHashCode;
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = HashCode.Combine(Id);
                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        
        }

        // 1.5 It is worth pointing out that, once we've redefined the Object.Equals method in the
        // Entity class, we can also override the == and != operators.
        public static bool operator == (Entity<K> left, Entity<K> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));
            else
                return left.Equals(right);
        }

        // 1.5 It is worth pointing out that, once we've redefined the Object.Equals method in the
        // Entity class, we can also override the == and != operators.
        public static bool operator != (Entity<K> left, Entity<K> right)
        {
            return !(left == right);
        }
        
        [NotMapped]
        public List<IEventNotification> DomainEvents { get; private set; }
        public void AddDomainEvent(IEventNotification evt)
        {
            DomainEvents ??= new List<IEventNotification>();
            DomainEvents.Add(evt);
        }
        public void RemoveDomainEvent(IEventNotification evt)
        {
            DomainEvents?.Remove(evt);
        }
    }
}
