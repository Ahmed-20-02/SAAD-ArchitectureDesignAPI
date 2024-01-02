namespace SoftwareArchitectureDesignAPI.Data.Commands
{
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Data.Queries.Interfaces;
    using SoftwareArchitectureDesignAPI.Resources;
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data.Commands.Interfaces;
    using SoftwareArchitectureDesignAPI.Data.Queries;

    public class CreateApplicationDocumentCommand : ICreateApplicationDocumentCommand
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;
        private readonly IGetApplicationByKeyQuery _getApplicationByKeyQuery;
        private readonly IGetVisaDocumentByKeyQuery _getVisaDocumentByKeyQuery;

        public CreateApplicationDocumentCommand(IDbContextFactory<DataContext> contextFactory,
            IGetApplicationByKeyQuery getApplicationByKeyQuery,
            IGetVisaDocumentByKeyQuery getVisaDocumentByKeyQuery)
        {
            _contextFactory = contextFactory;
            _getApplicationByKeyQuery = getApplicationByKeyQuery;
            _getVisaDocumentByKeyQuery = getVisaDocumentByKeyQuery;
        }

        public void Create(CreateDocumentModel createDocumentModel)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var applicationDocument = new ApplicationDocument();

                    applicationDocument.FileName = createDocumentModel.document.fileName;
                    applicationDocument.FilePath = createDocumentModel.document.filePath;
                    applicationDocument.UploadedDate = DateTime.Now;
                    /*applicationDocument.Application = this._getApplicationByKeyQuery
                        .Get(createDocumentModel.applicationId).Result;
                    applicationDocument.VisaDocument = _getVisaDocumentByKeyQuery
                        .Get(createDocumentModel.visaDocumentId).Result;*/
                    applicationDocument.ApplicationId = createDocumentModel.applicationId;
                    applicationDocument.VisaDocumentId = createDocumentModel.visaDocumentId;

                    context.ApplicationsDocuments.Add(applicationDocument);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}