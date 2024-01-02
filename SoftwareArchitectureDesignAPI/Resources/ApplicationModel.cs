namespace SoftwareArchitectureDesignAPI.Resources
{
    public class ApplicationModel
    {
        private int userId { get; set; }
        public int visaId { get; set; }
        public Dictionary<int, ApplicationDocumentModel> DocumentPaths { get; set; }
    }
}

