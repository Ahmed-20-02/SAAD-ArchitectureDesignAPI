namespace UnitTests.Business.Creators
{
    using Moq;
    using SoftwareArchitectureDesignAPI.Resources;
    using SoftwareArchitectureDesignAPI.Business.Creators;
    using SoftwareArchitectureDesignAPI.Data.Commands.Interfaces;
    using SoftwareArchitectureDesignAPI.Data.Entities;
    
    public class ApplicationCreatorTests : TestBase<ApplicationCreator>
    {
        SubmissionRequest stubRequest = new()
        {
            userId = 1234,
            Application = new ApplicationModel()
            {
                visaId = 1,
                DocumentPaths = new Dictionary<int, ApplicationDocumentModel>()
                {
                    {
                        1, new ApplicationDocumentModel()
                        {
                            fileName = "TestName",
                            filePath = "TestPath"
                        }
                    }
                }
            }
        };
        
        [Fact]
        public void CreateRunsApplicationCommand()
        {
            this.AutoMocker.GetMock<ICreateApplicationCommand>()
                .Setup(x => x.Create(stubRequest)).Returns(new Application());
            
            var sut = this.CreateTestSubject();

            var result = sut.Create(stubRequest);

            Assert.NotNull(result);

            this.AutoMocker.GetMock<ICreateApplicationCommand>()
                .Verify(x => x.Create(stubRequest), Times.Once);
        }

        [Fact]
        public void CreateHitsException()
        {
            this.AutoMocker.GetMock<ICreateApplicationCommand>()
                .Setup(x => x.Create(stubRequest)).Throws(new Exception());
            
            var sut = this.CreateTestSubject();

            var ex = Assert.Throws<Exception>(() => sut.Create(stubRequest));
            
            Assert.IsType<Exception>(ex);
            Assert.Equal(ExceptionMessage,ex.Message);
        }
    }
}