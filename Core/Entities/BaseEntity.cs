using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BaseEntity<T>
    {    
        public T Id { get; set; }
        
    }
}