namespace UnitTests.Controllers
{
    using SoftwareArchitectureDesignAPI.Controllers;
    using Moq;
    using SoftwareArchitectureDesignAPI.Resources;
    using SoftwareArchitectureDesignAPI.Logger;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc;
    using SoftwareArchitectureDesignAPI.Business.Processors.Interfaces;

    public class AppplicationControllerTests : TestBase<ApplicationController>
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
        public void SubmitApplicationReturnsExpectedResult()
        {
            this.AutoMocker.GetMock<ILogger>()
                .Setup(x => x.Log(It.IsAny<string>()));

            var expected = new SubmissionResponse()
            {
                UserId = 1234,
                ApplicationId = 4321,
                Message = "Submission Success"
            };
            
            this.AutoMocker.GetMock<ISubmissionProcessor>()
                .Setup(x => x.Process(stubRequest)).Returns(expected);
            
            var sut = this.CreateTestSubject();

            var result = sut.SubmitApplication(stubRequest);

            Assert.IsType<OkObjectResult>(result);
            
            Assert.Equal(JsonConvert.SerializeObject(new OkObjectResult(expected)), JsonConvert.SerializeObject(result));
        }
        
        [Fact]
        public void SubmitApplicationHitsException()
        {
            this.AutoMocker.GetMock<ILogger>()
                .Setup(x => x.Log(It.IsAny<string>())).Throws(new Exception(ExceptionMessage));;
            
            var sut = this.CreateTestSubject();

            var result = sut.SubmitApplication(stubRequest);
            
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(JsonConvert.SerializeObject(new BadRequestObjectResult(ExceptionMessage)),
                JsonConvert.SerializeObject(result));

        }
    }
}