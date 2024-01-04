using System.Net;

namespace SoftwareArchitectureDesignAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoftwareArchitectureDesignAPI.Business.Processors.Interfaces;
    using SoftwareArchitectureDesignAPI.Resources;
    using System.IO;

    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly ISubmissionProcessor _submissionProcessor;

        public ApplicationController(ILogger<ApplicationController> logger,
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
               // string rt = "";
                /*using (StreamWriter writer = new StreamWriter("D:\\Github Repos\\SAAD-ArchitectureDesignAPI\\Logs.txt"))
                {
                    /*writer.WriteLine($"Starting submission process for user id {request.userId} " +
                                     $"and visa id {request.Application.visaId}");#1#
                    
                }*/
                
                return new OkObjectResult(System.IO.File.ReadAllText("D:\\Github Repos\\SAAD-ArchitectureDesignAPI\\Logs.txt"));
                
              //  return new OkObjectResult(_submissionProcessor.Process(request));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}