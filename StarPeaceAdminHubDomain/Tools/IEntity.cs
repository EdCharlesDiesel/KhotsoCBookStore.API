using System;
using System.Collections.Generic;
using System.Text;
//using System.ComponentModel.DataAnnotations.Validator;

namespace DDD.DomainLayer
{

    // 1.0 It is also worth implementing an IEntity<K> interface that defines all the properties/
    // methods of Entity<K>. This interface is useful whenever we need to hide data classes
    // behind interfaces.
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
