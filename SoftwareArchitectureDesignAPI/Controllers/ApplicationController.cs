using Microsoft.EntityFrameworkCore;
using SoftwareArchitectureDesignAPI.Data;

namespace SoftwareArchitectureDesignAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public ApplicationController(ILogger<ApplicationController> logger, 
            IDbContextFactory<DataContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }

        [HttpPost("submitapplication")]
        public IActionResult SubmitApplication()
        {
            var context = _contextFactory.CreateDbContext();
            var test = context.Countries.ToList();
            
            return new OkObjectResult(test) ;
            
            /*using (var context = _contextFactory.CreateDbContext())
            {
                return new OkObjectResult(context.Countries.ToList()) ;
            }*/
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