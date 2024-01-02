namespace SoftwareArchitectureDesignAPI.Data.Queries
{
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Data.Queries.Interfaces;

    public class GetUserByKeyQuery : IGetUserByKeyQuery
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public GetUserByKeyQuery(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<User> Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
               return context.Users.Include("Role").FirstOrDefaultAsync(x => x.UserId == id).Result
                       ?? throw new NullReferenceException("No user found");
            }
        }
    }
}