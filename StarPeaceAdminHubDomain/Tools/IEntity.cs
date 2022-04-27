using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Validator;

namespace DDD.DomainLayer
{
    public interface IEntity<K> where K : IEquatable<K>
    {
        K Id { get; }
        bool IsTransient();
        List<IEventNotification> DomainEvents { get; }
        void AddDomainEvent(IEventNotification evt);
        void RemoveDomainEvent(IEventNotification evt);        

        // TryValidateObject(this IsTransient zc) 
        // {
        //     //validate
        // }

        // public static bool TryValidateProperty( Object value,
        //                                         ValidationContext validationContext,
        //                                         ICollection<ValidationResult> validationResults)
        // {
        //     //validate
        // }


    }
}
