namespace WebApplication2.Controllers
{
    using System;
    using System.Net;
    using MainService.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Controller for API 2 endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private ILogger<MainController> logger;
        private readonly IExtra extraService;
        private readonly ICalc calcService;

        /// <summary>
        /// CalcRateController constructor.
        /// </summary>
        public MainController(ILogger<MainController> _logger, IExtra extraService, ICalc calcService)
        {
            this.logger = _logger;
            this.extraService = extraService;
            this.calcService = calcService;
        }

        /// <summary>
        /// Shows the repository URL of this project.
        /// </summary>
        /// <returns>the URL.</returns>
        [HttpGet("showmethecode")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        public ActionResult<string> ShowMeTheCode()
        {
            try
            {
                var result = this.extraService.ShowMeTheCode();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Calculate a final ammount from an interest rate upon an initial ammount in a period of time.
        /// </summary>
        /// <param name="valorInicial">initial ammount.</param>
        /// <param name="meses">number of months.</param>
        /// <returns></returns>
        [HttpGet("calculajuros")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(decimal))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        public ActionResult<decimal> CalculateInterestRate(decimal valorInicial, int meses)
        {
            try
            {
                var result = this.calcService.CalculateFinalAmmount(valorInicial, meses);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return this.BadRequest(ex.Message);
            }
        }
    }
}
