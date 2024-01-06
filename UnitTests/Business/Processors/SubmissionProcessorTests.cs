namespace UnitTests.Business.Processors
{
    using Moq;
    using SoftwareArchitectureDesignAPI.Resources;
    using SoftwareArchitectureDesignAPI.Logger;
    using SoftwareArchitectureDesignAPI.Business.Processors;
    using Newtonsoft.Json;
    using SoftwareArchitectureDesignAPI.Business.Creators.Interfaces;
    using SoftwareArchitectureDesignAPI.Data.Entities;


    public class SubmissionProcessorTests : TestBase<SubmissionProcessor>
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
                    }, 
                    { 
                        2, new ApplicationDocumentModel()
                        {
                            fileName = "TestNameTwo",
                            filePath = "TestPathTwo"
                        }
                    }
                }
            }
        };
        
        CreateDocumentModel stubModel = new ()
        {
            applicationId = 5,
            visaDocumentId = 1,
            document = new ApplicationDocumentModel()
            {
                fileName = "TestName",
                filePath = "TestPath"
            }
        };
        
        CreateDocumentModel stubModelTwo = new ()
        {
            applicationId = 5,
            visaDocumentId = 2,
            document = new ApplicationDocumentModel()
            {
                fileName = "TestNameTwo",
                filePath = "TestPathTwo"
            }
        };

        [Fact]
        public void ProcessProcessesApplication()
        {
            var stubApplicationId = 5;
            
            this.AutoMocker.GetMock<ILogger>()
                .Setup(x => x.Log(It.IsAny<string>()));
            
            this.AutoMocker.GetMock<IApplicationCreator>()
                .Setup(x => x.Create(stubRequest)).Returns(
                    new Application {ApplicationId = stubApplicationId});
            
            this.AutoMocker.GetMock<IApplicationDocumentCreator>()
                .Setup(x => x.Create(stubModel));
            
            this.AutoMocker.GetMock<IApplicationDocumentCreator>()
                .Setup(x => x.Create(stubModelTwo));
            
            var expected = new SubmissionResponse()
            {
                UserId = stubRequest.userId,
                Message = "Submission Success",
                ApplicationId = stubApplicationId
            };
            
            var sut = this.CreateTestSubject();

            var result = sut.Process(stubRequest);
            
            this.AutoMocker.GetMock<ILogger>()
                .Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(3));
            
            this.AutoMocker.GetMock<IApplicationCreator>()
                .Verify(x => x.Create(stubRequest), Times.Once);
            
            this.AutoMocker.GetMock<IApplicationDocumentCreator>()
                .Verify(x => x.Create(It.IsAny<CreateDocumentModel>()), Times.Exactly(2));
            
            Assert.Equal(JsonConvert.SerializeObject(expected) , JsonConvert.SerializeObject(result));
        }
        
        [Fact]
        public void CreateHitsException()
        {
            this.AutoMocker.GetMock<ILogger>()
                .Setup(x => x.Log(It.IsAny<string>())).Throws(new Exception());
            
            var sut = this.CreateTestSubject();

            var ex = Assert.Throws<Exception>(() => sut.Process(stubRequest));
            
            Assert.IsType<Exception>(ex);
            Assert.Equal(ExceptionMessage,ex.Message);
        }
    }
}