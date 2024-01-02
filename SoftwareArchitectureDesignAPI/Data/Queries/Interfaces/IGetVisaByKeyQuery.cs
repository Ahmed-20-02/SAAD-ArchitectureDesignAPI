namespace SoftwareArchitectureDesignAPI.Data.Queries.Interfaces
{
    using SoftwareArchitectureDesignAPI.Data.Entities;

    public interface IGetVisaByKeyQuery
    {
        Task<Visa> Get(int id);
    }
}