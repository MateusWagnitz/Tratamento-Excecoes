

using System;

namespace Problema_exemplo.Entities.Exceptions
{
    class DomainException : ApplicationException //do system
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
