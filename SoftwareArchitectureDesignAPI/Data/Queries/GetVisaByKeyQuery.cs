namespace SoftwareArchitectureDesignAPI.Data.Queries
{
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Data.Queries.Interfaces;

    public class GetVisaByKeyQuery : IGetVisaByKeyQuery
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public GetVisaByKeyQuery(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Visa> Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Visas.Include("Country").FirstOrDefault(x => x.VisaId == id)
                       ?? throw new NullReferenceException("No Visa found");
            }
        }
    }
}