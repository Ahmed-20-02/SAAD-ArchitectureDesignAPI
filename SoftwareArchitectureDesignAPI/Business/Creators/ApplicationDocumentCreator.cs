namespace SoftwareArchitectureDesignAPI.Business.Creators
{
    using SoftwareArchitectureDesignAPI.Data.Commands.Interfaces;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Resources;
    using SoftwareArchitectureDesignAPI.Business.Creators.Interfaces;
    
    public class ApplicationDocumentCreator : IApplicationDocumentCreator
    {
        private readonly ICreateApplicationDocumentCommand _createApplicationDocumentCommand;

        public ApplicationDocumentCreator(ICreateApplicationDocumentCommand createApplicationDocumentCommand)
        {
            _createApplicationDocumentCommand = createApplicationDocumentCommand;
        }

        public void Create(CreateDocumentModel createDocumentModel)
        {
            try
            {
                _createApplicationDocumentCommand.Create(createDocumentModel);
            }

            catch (Exception e)
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}