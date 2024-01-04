namespace SoftwareArchitectureDesignAPI.Data.Commands
{
    using SoftwareArchitectureDesignAPI.Data.Entities;
    using SoftwareArchitectureDesignAPI.Resources;
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data.Commands.Interfaces;

    public class CreateApplicationDocumentCommand : ICreateApplicationDocumentCommand
    {
        private readonly IDbContextFactory<DataContext> _contextFactory;

        public CreateApplicationDocumentCommand(IDbContextFactory<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
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
                    applicationDocument.ApplicationId = createDocumentModel.applicationId;
                    applicationDocument.VisaDocumentId = createDocumentModel.visaDocumentId;

                    context.ApplicationsDocuments.Add(applicationDocument);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}