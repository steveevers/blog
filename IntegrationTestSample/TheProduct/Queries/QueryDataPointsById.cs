using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheProduct.Data;
using TheProduct.DataContracts;

namespace TheProduct.Queries
{
    public class QueryDataPointsById
    {
        public class Request : IRequest<Outcome> 
        {
            public Guid Id { get; }

            public Request(Guid id)
            {
                this.Id = id;
            }
        }

        public class Handler : IRequestHandler<Request, Outcome>
        {
            private ProductContext dbContext;
            private IMapper mapper;

            public Handler(ProductContext context, IMapper mapper)
            {
                this.dbContext = context;
                this.mapper = mapper;
            }

            public async Task<Outcome> Handle(Request request, CancellationToken cancellationToken)
            {
                var dp = await dbContext.DataPoints.FindAsync(request.Id);
                if (dp == null)
                    return new Outcomes.NotFound();

                return new Outcomes.Succss<DataPointDto>(mapper.Map<DataPointDto>(dp));
            }
        }
    }
}
