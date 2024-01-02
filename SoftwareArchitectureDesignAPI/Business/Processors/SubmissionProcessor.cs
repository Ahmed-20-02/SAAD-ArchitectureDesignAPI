namespace SoftwareArchitectureDesignAPI.Business.Processors
{
    using SoftwareArchitectureDesignAPI.Resources;
    using SoftwareArchitectureDesignAPI.Business.Creators.Interfaces;
    using SoftwareArchitectureDesignAPI.Business.Processors.Interfaces;

    public class SubmissionProcessor : ISubmissionProcessor
    {
        private readonly IApplicationCreator _applicationCreator;
        private readonly IApplicationDocumentCreator _applicationDocumentCreator;

        public SubmissionProcessor(IApplicationCreator applicationCreator,
            IApplicationDocumentCreator applicationDocumentCreator)
        {
            _applicationCreator = applicationCreator;
            _applicationDocumentCreator = applicationDocumentCreator;
        }

        public SubmissionResponse Process(SubmissionRequest request)
        {
            try
            {
                var application = _applicationCreator.Create(request);

                foreach (var doc in request.Application.DocumentPaths)
                {
                    var model = new CreateDocumentModel()
                    {
                        applicationId = application.ApplicationId,
                        visaDocumentId = doc.Key,
                        document = new ApplicationDocumentModel()
                        {
                            fileName = doc.Value.fileName,
                            filePath = doc.Value.filePath
                        }
                    };

                    _applicationDocumentCreator.Create(model);
                }

                return new SubmissionResponse()
                {
                    UserId = request.UserId,
                    Message = "Submission Success",
                    ApplicationId = application.ApplicationId
                };
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}