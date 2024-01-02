namespace SoftwareArchitectureDesignAPI.Business.Processors.Interfaces
{
    using SoftwareArchitectureDesignAPI.Resources;

    public interface ISubmissionProcessor
    {
        SubmissionResponse Process(SubmissionRequest request);
    }
}