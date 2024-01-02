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

        public User Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Users.Include("Role").FirstOrDefault(x => x.UserId == id);
            }
        }
    }
}