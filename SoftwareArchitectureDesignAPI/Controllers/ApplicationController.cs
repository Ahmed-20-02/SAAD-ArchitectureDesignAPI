namespace SoftwareArchitectureDesignAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data;
    using SoftwareArchitectureDesignAPI.Data.Queries.Interfaces;

    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IDbContextFactory<DataContext> _contextFactory;
        private readonly IGetUserByKeyQuery _getUserByKeyQuery;

        public ApplicationController(ILogger<ApplicationController> logger, 
            IDbContextFactory<DataContext> contextFactory, 
            IGetUserByKeyQuery getUserByKeyQuery)
        {
            _logger = logger;
            _contextFactory = contextFactory;
            _getUserByKeyQuery = getUserByKeyQuery;
        }

        [HttpPost("submitapplication")]
        public IActionResult SubmitApplication(/*[FromBody] SubmissionRequest request*/)
        {
            
            
            /*using (var cntxt = _contextFactory.CreateDbContext())
            {
                var test = cntxt.Users.Include("Role").ToList();
                return new OkObjectResult(test) ;
            }*/

            return new OkObjectResult(_getUserByKeyQuery.Get(1)) ;
            
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

            return new OkObjectResult("APPROVED");
        }
    }
}