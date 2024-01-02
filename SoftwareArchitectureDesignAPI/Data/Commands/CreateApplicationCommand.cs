using SoftwareArchitectureDesignAPI.Data.Entities;

namespace SoftwareArchitectureDesignAPI.Data.Commands
{
    using SoftwareArchitectureDesignAPI.Resources;
    using Microsoft.EntityFrameworkCore;

    public class CreateApplicationCommand
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public CreateApplicationCommand(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }


        public void Create(SubmissionRequest request)
        {
            /*using (var context = _contextFactory.CreateDbContext())
            {
                context.Applications.Add(new Application()
                {
                    Status = "Received",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    User = 
                    
                });
            }*/
        }
    }
}