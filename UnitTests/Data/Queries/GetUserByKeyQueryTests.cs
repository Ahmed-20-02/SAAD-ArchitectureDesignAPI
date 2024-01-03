using Microsoft.EntityFrameworkCore;
using Moq;
using SoftwareArchitectureDesignAPI.Data;
using SoftwareArchitectureDesignAPI.Data.Entities;

namespace UnitTests.Data.Queries
{
    using Moq.AutoMock;

    public class GetUserByKeyQueryTests : AutoMocker
    {
        [Fact]
        public void GetReturnsExpectedUser()
        {
           var mocker = new AutoMocker();
           
           var mockSet = new Mock<DbSet<User>>();

           
           
           var mockContext = new Mock<DataContext>();
           mockContext.Setup(m => m.Users).Returns(mockSet.Object);
   
           
           
        }
    }
}

