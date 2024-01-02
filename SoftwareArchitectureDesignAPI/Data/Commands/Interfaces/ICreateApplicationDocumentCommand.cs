namespace SoftwareArchitectureDesignAPI.Data.Commands.Interfaces
{
    using SoftwareArchitectureDesignAPI.Resources;

    public interface ICreateApplicationDocumentCommand
    {
        void Create(CreateDocumentModel createDocumentModel);
    }
}