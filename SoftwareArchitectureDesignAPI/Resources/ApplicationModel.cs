namespace SoftwareArchitectureDesignAPI.Resources
{
    public class ApplicationModel
    {
        public int visaId { get; set; }
        public Dictionary<int , ApplicationDocumentModel> DocumentPaths { get; set; }
    }
}

