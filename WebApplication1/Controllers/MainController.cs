namespace WebApplication1.Controllers
{
    using System;
    using System.Net;
    using MainService.Contracts;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for API 1 endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ICalc calcService;

        /// <summary>
        /// RateController constructor.
        /// </summary>
        public MainController(ICalc calcService)
        {
            this.calcService = calcService;
        }

        /// <summary>
        /// Gets the interest rate.
        /// </summary>
        /// <returns>the interest rate.</returns>
        [HttpGet("taxaJuros")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(decimal))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        public ActionResult<decimal> GetInterestRate()
        {
            try
            {
                var result = this.calcService.GetInterestRate();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
