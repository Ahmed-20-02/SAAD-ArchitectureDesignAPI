namespace SoftwareArchitectureDesignAPI.Data.Queries
{
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Data.Queries.Interfaces;

    public class GetApplicationByKeyQuery : IGetApplicationByKeyQuery
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public GetApplicationByKeyQuery(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Application> Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Applications.Include("VisaId").Include("UserId").FirstOrDefaultAsync(x => x.ApplicationId == id).Result
                       ?? throw new NullReferenceException("No user found");
            }
        }
    }
}