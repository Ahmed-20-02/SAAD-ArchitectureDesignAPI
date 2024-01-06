namespace SoftwareArchitectureDesignAPI.Business.Creators
{
    using SoftwareArchitectureDesignAPI.Data.Commands.Interfaces;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Resources;
    using SoftwareArchitectureDesignAPI.Business.Creators.Interfaces;
    
    public class ApplicationCreator : IApplicationCreator
    {
        private readonly ICreateApplicationCommand _createApplicationCommand;

        public ApplicationCreator(ICreateApplicationCommand createApplicationCommand)
        {
            _createApplicationCommand = createApplicationCommand;
        }

        public Application Create(SubmissionRequest request)
        {
            try
            {
                return _createApplicationCommand.Create(request);
            }

            catch (Exception e)
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}