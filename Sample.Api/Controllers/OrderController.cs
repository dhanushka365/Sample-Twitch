using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Contracts;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly ILogger<OrderController> _logger;
        readonly IRequestClient<SubmitOrder> _submitOrderRequestClient;

        public OrderController(ILogger<OrderController> logger, IRequestClient<SubmitOrder> submitOrderRequestClient)
        {
            _logger = logger;
            _submitOrderRequestClient = submitOrderRequestClient;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SubmitOrder(Guid id , String customerNumber)
        {
            var response = await _submitOrderRequestClient.GetResponse<OrderSubmissionAccepted>(
                new
                {
                    OrderId = id,
                    Timestamp = InVar.Timestamp,
                    CustomerNumber = customerNumber,
                    Items = new[] { "item1", "item2" }
                });

            return Ok(response.Message);
        }

    }
}
