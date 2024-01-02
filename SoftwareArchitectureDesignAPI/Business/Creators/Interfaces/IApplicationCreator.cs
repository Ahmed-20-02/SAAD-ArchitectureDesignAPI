namespace SoftwareArchitectureDesignAPI.Business.Creators.Interfaces
{
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Resources;

    public interface IApplicationCreator
    {
        Application Create(SubmissionRequest request);
    }
}