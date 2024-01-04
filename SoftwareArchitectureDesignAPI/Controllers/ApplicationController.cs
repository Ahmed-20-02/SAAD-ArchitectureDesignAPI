namespace SoftwareArchitectureDesignAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoftwareArchitectureDesignAPI.Business.Processors.Interfaces;
    using SoftwareArchitectureDesignAPI.Resources;
    using ILogger = SoftwareArchitectureDesignAPI.Logger.ILogger;

    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISubmissionProcessor _submissionProcessor;

        public ApplicationController(ILogger logger,
            ISubmissionProcessor submissionProcessor)
        {
            _logger = logger;
            _submissionProcessor = submissionProcessor;
        }

        [HttpPost("submitapplication")]
        public IActionResult SubmitApplication( [FromBody] SubmissionRequest request)
        {
            try
            {
                this._logger.Log($"Starting submission process for user id {request.userId} " +
                                 $"and visa id {request.Application.visaId}");
                
                return new OkObjectResult(_submissionProcessor.Process(request));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}