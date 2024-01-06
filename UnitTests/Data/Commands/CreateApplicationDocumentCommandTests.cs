namespace UnitTests.Data.Commands
{
    using SoftwareArchitectureDesignAPI.Data.Commands;
    using SoftwareArchitectureDesignAPI.Resources;
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data;
    
    public class CreateApplicationDocumentCommandTests : TestBase<CreateApplicationDocumentCommand>
    {
        CreateDocumentModel stubDocumentModel = new()
        {
            visaDocumentId = 2,
            applicationId = 5,
            document = new ApplicationDocumentModel
            {
                fileName = "stubFileName",
                filePath = "stubFilePath"
            }
        };
        
        [Fact]
        public void CreateInsertsApplicationDocument()
        {
            var context = new TestDbContextFactory().CreateDbContext();
            

            this.AutoMocker.GetMock<IDbContextFactory<DataContext>>()
                .Setup(x => x.CreateDbContext())
                .Returns(context);

            Assert.Empty(context.ApplicationsDocuments);

            var sut = this.CreateTestSubject();

            sut.Create(stubDocumentModel);

            Assert.NotNull(context.ApplicationsDocuments);

            this.AutoMocker.GetMock<IDbContextFactory<DataContext>>()
                .Setup(x => x.CreateDbContext())
                .Returns(context);

            var updatedContext = new TestDbContextFactory().CreateDbContext();

            Assert.Equal( stubDocumentModel.document.fileName, updatedContext.ApplicationsDocuments.FirstOrDefault().FileName);
        }
        
        [Fact]
        public void CreateHitsException()
        {
            var sut = this.CreateTestSubject();

            var ex = Assert.Throws<Exception>(() => sut.Create(stubDocumentModel));
            
            Assert.IsType<Exception>(ex);
            Assert.Equal(ExceptionMessage,ex.Message);
        }
    }
}