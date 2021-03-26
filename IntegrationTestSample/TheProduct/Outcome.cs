using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheProduct
{
    public abstract record Outcome { }

    namespace Outcomes
    {
        public record NotFound : Outcome { }
        public record NotAuthorized : Outcome { }
        public record Succss<T> : Outcome
        {
            public T Data { get; }

            public Succss(T data)
            {
                this.Data = data;
            }
        }
    }
}
