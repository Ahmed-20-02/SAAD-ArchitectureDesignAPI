namespace SoftwareArchitectureDesignAPI.Data.Commands
{
    using SoftwareArchitectureDesignAPI.Data.Commands.Interfaces;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Resources;
    using Microsoft.EntityFrameworkCore;
    using ILogger = SoftwareArchitectureDesignAPI.Logger.ILogger;


    public class CreateApplicationCommand : ICreateApplicationCommand
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        private readonly ILogger _logger;
        
        public CreateApplicationCommand(IDbContextFactory<DataContext> contextFactory, 
            ILogger logger)
        {
            _contextFactory = contextFactory;
            _logger = logger;
        }

        public Application Create(SubmissionRequest request)
        {
            try
            {
                _logger.Log($"Inserting application for user id {request.userId} " +
                                       $"and visa id {request.Application.visaId}");
                
                using (var context = _contextFactory.CreateDbContext())
                {
                    var application = new Application();

                    application.Status = "Received";
                    application.CreatedDate = DateTime.Now;
                    application.UpdatedDate = DateTime.Now;
                    application.UserId = request.userId;
                    application.VisaId = request.Application.visaId;

                    context.Applications.Add(application);
                    context.SaveChanges();

                    return application;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}