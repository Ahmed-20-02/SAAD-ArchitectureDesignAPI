namespace UnitTests.Business.Creators
{
    using Moq;
    using SoftwareArchitectureDesignAPI.Resources;
    using SoftwareArchitectureDesignAPI.Business.Creators;
    using SoftwareArchitectureDesignAPI.Data.Commands.Interfaces;
    
    public class ApplicationDocumentCreatorTests : TestBase<ApplicationDocumentCreator>
    {
        private CreateDocumentModel stubDocumentModel = new()
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
        public void CreateRunsApplicationCommand()
        {
            this.AutoMocker.GetMock<ICreateApplicationDocumentCommand>()
                .Setup(x => x.Create(stubDocumentModel));
            
            var sut = this.CreateTestSubject();

            sut.Create(stubDocumentModel);
            
            this.AutoMocker.GetMock<ICreateApplicationDocumentCommand>()
                .Verify(x => x.Create(stubDocumentModel), Times.Once);
        }

        [Fact]
        public void CreateHitsException()
        {
            this.AutoMocker.GetMock<ICreateApplicationDocumentCommand>()
                .Setup(x => x.Create(stubDocumentModel)).Throws(new Exception());
            
            var sut = this.CreateTestSubject();

            var ex = Assert.Throws<Exception>(() => sut.Create(stubDocumentModel));
            
            Assert.IsType<Exception>(ex);
            Assert.Equal(ExceptionMessage,ex.Message);
        }
    }
}