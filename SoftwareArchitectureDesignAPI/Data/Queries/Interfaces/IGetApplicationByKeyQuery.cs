namespace SoftwareArchitectureDesignAPI.Data.Queries.Interfaces
{
    using SoftwareArchitectureDesignAPI.Data.Entities;

    public interface IGetApplicationByKeyQuery
    {
        Task<Application> Get(int id);
    }
}