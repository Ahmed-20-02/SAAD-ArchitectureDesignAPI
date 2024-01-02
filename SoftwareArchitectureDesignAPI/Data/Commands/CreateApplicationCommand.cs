namespace SoftwareArchitectureDesignAPI.Data.Commands
{
    using SoftwareArchitectureDesignAPI.Data.Commands.Interfaces;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Data.Queries.Interfaces;
    using SoftwareArchitectureDesignAPI.Resources;
    using Microsoft.EntityFrameworkCore;

    public class CreateApplicationCommand : ICreateApplicationCommand
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        private readonly IGetUserByKeyQuery _getUserByKeyQuery;
        private readonly IGetVisaByKeyQuery _getVisaByKeyQuery;

        public CreateApplicationCommand(IDbContextFactory<DataContext> contextFactory,
            IGetUserByKeyQuery getUserByKeyQuery,
            IGetVisaByKeyQuery getVisaByKeyQuery)
        {
            _contextFactory = contextFactory;
            _getUserByKeyQuery = getUserByKeyQuery;
            _getVisaByKeyQuery = getVisaByKeyQuery;
        }

        public Application Create(SubmissionRequest request)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var application = new Application();

                    application.Status = "Received";
                    application.CreatedDate = DateTime.Now;
                    application.UpdatedDate = DateTime.Now;
                    /*application.User = this._getUserByKeyQuery.Get(request.UserId).Result;
                    application.Visa = this._getVisaByKeyQuery.Get(request.Application.visaId).Result;*/
                    application.UserId = request.UserId;
                    application.VisaId = request.Application.visaId;

                    /*context.Applications.Add(new Application()
                    {
                        Status = "Received",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        User = this._getUserByKeyQuery.Get(request.UserId).Result,
                        Visa = this._getVisaByKeyQuery.Get(request.Application.visaId).Result
                    });*/
                    context.Applications.Add(application);
                    context.SaveChanges();

                    return application;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}