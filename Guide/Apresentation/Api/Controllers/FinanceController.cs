using Applications.Finance.Commands;
using Applications.Finance.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/guide/finance")]

    public class FinanceController : Controller
    {
        private readonly IMediator _mediator;


        public FinanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post()
        {
            var query = new FinanceUpdateDataBaseCommand();

            return Ok(await _mediator.Send(query));
        }


        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = new FinanceGetDataQuery();

                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
