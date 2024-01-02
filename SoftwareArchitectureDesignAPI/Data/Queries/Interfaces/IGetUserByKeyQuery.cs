namespace SoftwareArchitectureDesignAPI.Data.Queries.Interfaces
{
    using SoftwareArchitectureDesignAPI.Data.Entities;

    public interface IGetUserByKeyQuery
    {
        Task<User> Get(int id);
    }
}