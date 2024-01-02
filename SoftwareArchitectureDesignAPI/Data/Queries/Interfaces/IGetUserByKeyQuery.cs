namespace SoftwareArchitectureDesignAPI.Data.Queries.Interfaces
{
    using SoftwareArchitectureDesignAPI.Data.Entities;
    
    public interface IGetUserByKeyQuery
    {
        User Get(int id);
    }
}