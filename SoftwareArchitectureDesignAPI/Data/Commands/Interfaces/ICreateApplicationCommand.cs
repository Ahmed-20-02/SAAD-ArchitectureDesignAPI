namespace SoftwareArchitectureDesignAPI.Data.Commands.Interfaces
{
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Resources;

    public interface ICreateApplicationCommand
    {
        Application Create(SubmissionRequest request);
    }
}