namespace SoftwareArchitectureDesignAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(ILogger<ApplicationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("submitapplication")]
        public IActionResult SubmitApplication()
        {
            return new OkObjectResult("SUBMITTED") ;
        }
        
        [HttpPost("approveapplication")]
        public IActionResult ApproveApplication()
        {
            /*var x = new SubmissionRequest()
            {
                application = new Application(),
                userId = 123
            };*/
            
            return new OkObjectResult("APPROVED") ;
        }
    }
}