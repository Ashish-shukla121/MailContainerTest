using XUnit;

namespace MailContainerTest.Tests.ServicesTestCases
{
    public class MailTransferServiceTest : IMailTransferService
    {
        private readonly IMailContainer _mailContainerStatus;
        public MailTransferServiceTest(IMailContainer mailContainer)
        {
            _mailContainerStatus = mailContainer;
        }
        [Theory]
        // To moq the type we can use mocking tools like fixture
        [InlineData(typeof(MakeMailTransferRequest))]
        public void MakeMailTransfer_ReturnsExceptionAsContainerIsNonOperational(MakeMailTransferRequest request)
        {
            // Arrange
            object req = request;
            var mailServiceObj = new MailTransferServiceTest();
            MailContainer mailContainer = "Non-Operational";
            //Act
            var result = mailServiceObj.MakeMailTransfer(req);
            //Assert
            Assert.Contains("is not in opretational state");
        }

        [Theory]
        [InlineData(typeof(MakeMailTransferRequest))]
        [InlineData("This is string")]
        public void MakeMailTransfer_ReturnsFalseAsNoProperInputProvided(MakeMailTransferRequest request)
        {
            // Arrange
            object req = request;
            var mailServiceObj = new MailTransferServiceTest();
            MailContainer mailContainer = "Operational";
            //Act
            var result = mailServiceObj.MakeMailTransfer(req);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }


        [Theory]
        [InlineData(typeof(MakeMailTransferRequest))]
        [InlineData("This is string")]
        public void MakeMailTransfer_ReturnsSuccess(MakeMailTransferRequest request)
        {
            // Arrange
            object req = request;
            var mailServiceObj = new MailTransferServiceTest();
            MailContainer mailContainer = "Operational";
            //Act
            var result = mailServiceObj.MakeMailTransfer(req);
            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
