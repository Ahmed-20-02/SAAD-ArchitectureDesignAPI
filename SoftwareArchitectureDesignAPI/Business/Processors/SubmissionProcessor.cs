namespace SoftwareArchitectureDesignAPI.Business.Processors
{
    using SoftwareArchitectureDesignAPI.Resources;
    using SoftwareArchitectureDesignAPI.Business.Creators.Interfaces;
    using SoftwareArchitectureDesignAPI.Business.Processors.Interfaces;
    using ILogger = SoftwareArchitectureDesignAPI.Logger.ILogger;

    public class SubmissionProcessor : ISubmissionProcessor
    {
        private readonly IApplicationCreator _applicationCreator;
        private readonly IApplicationDocumentCreator _applicationDocumentCreator;
        private readonly ILogger _logger;


        public SubmissionProcessor(IApplicationCreator applicationCreator,
            IApplicationDocumentCreator applicationDocumentCreator, 
            ILogger logger)
        {
            _applicationCreator = applicationCreator;
            _applicationDocumentCreator = applicationDocumentCreator;
            _logger = logger;
        }

        public SubmissionResponse Process(SubmissionRequest request)
        {
            try
            {
                var application = _applicationCreator.Create(request);

                foreach (var doc in request.Application.DocumentPaths)
                {
                    _logger.Log($"Inserting document record {doc.Value.fileName} for application " +
                                           $"{application.ApplicationId}");
                    
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

                _logger.Log($"Finished submission process for user id {request.userId} " +
                                       $"and visa id. Application id {application.ApplicationId}");                
                return new SubmissionResponse()
                {
                    UserId = request.userId,
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