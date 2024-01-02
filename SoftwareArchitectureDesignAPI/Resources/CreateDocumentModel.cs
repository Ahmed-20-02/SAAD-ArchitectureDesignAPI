namespace SoftwareArchitectureDesignAPI.Resources
{
    public class CreateDocumentModel
    {
        public int visaDocumentId { get; set; }
        public int applicationId { get; set; }
        public ApplicationDocumentModel document { get; set; }
    }
}