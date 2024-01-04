
namespace SoftwareArchitectureDesignAPI.Data.Queries
{
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Data.Queries.Interfaces;


    public class GetVisaDocumentByKeyQuery : IGetVisaDocumentByKeyQuery
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public GetVisaDocumentByKeyQuery(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<VisaDocument> Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.VisaDocuments.Include("Visa").Include("Document").FirstOrDefaultAsync(x => x.VisaDocumentId == id).Result
                       ?? throw new NullReferenceException("No user found");
            }
        }
    }
}