using Microsoft.EntityFrameworkCore;
using SoftwareArchitectureDesignAPI.Data;
using SoftwareArchitectureDesignAPI.Data.Entities;

namespace SoftwareArchitectureDesignAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoftwareArchitectureDesignAPI.Business.Processors.Interfaces;
    using SoftwareArchitectureDesignAPI.Resources;

    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly ISubmissionProcessor _submissionProcessor;
        private readonly IDbContextFactory<DataContext> _contextFactory;


        public ApplicationController(ILogger<ApplicationController> logger,
            ISubmissionProcessor submissionProcessor,
            IDbContextFactory<DataContext> contextFactory)
        {
            _logger = logger;
            _submissionProcessor = submissionProcessor;
            _contextFactory = contextFactory;
        }

        [HttpPost("submitapplication")]
        public IActionResult SubmitApplication( [FromBody] SubmissionRequest request)
        {
            /*using (var cntxt = _contextFactory.CreateDbContext())
            {
                var test = cntxt.Users.Include("Role").ToList();
                return new OkObjectResult(test) ;
            }*/
            
            /*using (var context = _contextFactory.CreateDbContext())
            {
                /*context.Documents.Add(new Document()
                {
                    Name = "TEST"
                });

                context.SaveChanges();#1#
                
                return new OkObjectResult(context.Documents);
            }*/

            try
            {
                return new OkObjectResult(_submissionProcessor.Process(request));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
            
           // return new OkObjectResult(_getUserByKeyQuery.Get(1));

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