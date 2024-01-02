namespace SoftwareArchitectureDesignAPI.Business.Creators.Interfaces
{
    using SoftwareArchitectureDesignAPI.Resources;

    public interface IApplicationDocumentCreator
    {
        void Create(CreateDocumentModel createDocumentModel);
    }
}