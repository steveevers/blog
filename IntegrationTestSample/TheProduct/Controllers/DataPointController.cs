using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TheProduct.DataContracts;
using TheProduct.Queries;

namespace TheProduct.Controllers
{
    [Route("api")]
    public class DataPointController : Controller
    {
        private IMediator mediator;

        public DataPointController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("datapoints/{id}")]
        public async Task<IActionResult> GetDataPoints(Guid id)
        {
            var result = await mediator.Send(new QueryDataPointsById.Request(id));
            return result switch
            {
                Outcomes.NotFound _ => NotFound(),
                Outcomes.Succss<DataPointDto> response => Ok(response.Data),
                _ => new StatusCodeResult((int)HttpStatusCode.InternalServerError)
            };
        }
    }
}
