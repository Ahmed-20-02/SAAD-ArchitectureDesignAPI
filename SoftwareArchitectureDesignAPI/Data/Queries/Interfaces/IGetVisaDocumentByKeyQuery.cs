namespace SoftwareArchitectureDesignAPI.Data.Queries
{
    using SoftwareArchitectureDesignAPI.Data.Entities;

    public interface IGetVisaDocumentByKeyQuery
    {
        Task<VisaDocument> Get(int id);
    }
}