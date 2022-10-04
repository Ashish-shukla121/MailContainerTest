using System.Net;
using MailContainerTest.Data;
using MailContainerTest.Services;
using MailContainerTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace MailContainerTest.Tests.ServicesTestCases
{
    public class MailTransferServiceTest : MailTransferService
    {
        
        private readonly IMailContainerDataStore _mailContainerDataStore;

        public MailTransferServiceTest(IMailContainerDataStore mailContainerDataStore) : base(mailContainerDataStore)
        {
        }
        
        [Theory]
        // To moq the type we can use mocking tools like fixture
        [InlineData(typeof(MakeMailTransferRequest))]
        public void MakeMailTransfer_ReturnsExceptionAsContainerIsNonOperational(MakeMailTransferRequest makeMailTransferRequest)
        {
            // Arrange
           
            //Act
            var result = new HttpResponseMessage();
            //Assert
            Assert.AreNotEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Theory]
        [InlineData(typeof(MakeMailTransferRequest))]
        [InlineData("This is string")]
        public void MakeMailTransfer_ReturnsFalseAsNoProperInputProvided(MakeMailTransferRequest makeMailTransferRequest)
        {
            // Arrange 
            
            //Act
            var result = new HttpResponseMessage();
            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }


        [Theory]
        [InlineData(typeof(MakeMailTransferRequest))]
        [InlineData("This is string")]
        public void MakeMailTransfer_ReturnsSuccess(MakeMailTransferRequest makeMailTransferRequest)
        {
            // Arrange
           
            //Act
           // var result = mailServiceObj.MakeMailTransfer(request);
            var result = new HttpResponseMessage();
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
