namespace UnitTests.Data.Commands
{
    using SoftwareArchitectureDesignAPI.Data.Commands;
    using Moq;
    using SoftwareArchitectureDesignAPI.Resources;
    using SoftwareArchitectureDesignAPI.Logger;
    using Microsoft.EntityFrameworkCore;
    using SoftwareArchitectureDesignAPI.Data;
    using Newtonsoft.Json;

    public class CreateApplicationCommandTests : TestBase<CreateApplicationCommand>
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
        public void CreateCreatesApplication()
        {
            var context = new TestDbContextFactory().CreateDbContext();

            this.AutoMocker.GetMock<ILogger>()
                .Setup(x => x.Log(It.IsAny<string>()));

            this.AutoMocker.GetMock<IDbContextFactory<DataContext>>()
                .Setup(x => x.CreateDbContext())
                .Returns(context);

            Assert.Empty(context.Applications);

            var sut = this.CreateTestSubject();

            var result = sut.Create(stubRequest);

            Assert.NotNull(result);

            this.AutoMocker.GetMock<ILogger>()
                .Verify(x => x.Log(It.IsAny<string>()), Times.Once);

            this.AutoMocker.GetMock<IDbContextFactory<DataContext>>()
                .Setup(x => x.CreateDbContext())
                .Returns(context);

            var updatedContext = new TestDbContextFactory().CreateDbContext();
            
            Assert.Equal(JsonConvert.SerializeObject(result) , JsonConvert.SerializeObject(updatedContext.Applications.FirstOrDefault()));
        }

        [Fact]
        public void CreateHitsException()
        {
            this.AutoMocker.GetMock<ILogger>()
                .Setup(x => x.Log(It.IsAny<string>())).Throws(new Exception());;
            
            var sut = this.CreateTestSubject();

            var ex = Assert.Throws<Exception>(() => sut.Create(stubRequest));
            
            Assert.IsType<Exception>(ex);
            Assert.Equal(ExceptionMessage,ex.Message);
        }
    }
}