using System.Collections.Generic;
using Domain;

namespace CreditorGuard.Domain
{
    public class UpsertDescriptor<T> where T : DomainBase
    {
        public bool Success { get; set; } = true;
        
        public List<string> Warnings { get; set; } = new List<string>();

        public T Object { get; set; }

        public UpsertDescriptor() { }

        public UpsertDescriptor(T obj)
        {
            Object = obj;
        }      
    }
}
