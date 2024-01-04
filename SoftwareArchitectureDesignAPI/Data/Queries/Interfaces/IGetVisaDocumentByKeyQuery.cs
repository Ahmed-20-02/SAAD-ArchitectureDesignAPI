namespace SoftwareArchitectureDesignAPI.Data.Queries.Interfaces
{
    using SoftwareArchitectureDesignAPI.Data.Entities;

    public interface IGetVisaDocumentByKeyQuery
    {
        Task<VisaDocument> Get(int id);
    }
}