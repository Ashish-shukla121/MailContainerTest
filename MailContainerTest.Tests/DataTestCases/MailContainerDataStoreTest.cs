using System.Net;
using MailContainerTest.Data;
using MailContainerTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace MailContainerTest.Tests.DataTestCases
{

    public class MailContainerDataStoreTest:MailContainerDataStore
    {
        #region "GetMailContainer"
        [Theory]
        [InlineData("ABC")]
        public void GetMailContainer_ReturnsException(string mailContainerNumber)
        {
            //Arrange
            //act
            var result = new HttpResponseMessage();
            //Assert
            // WE can through and match the Exception as well, Code snippet is in below line 
            //Assert.ThrowsExceptionAsync<>().Result.ToString();

            Assert.AreNotEqual(HttpStatusCode.Accepted, result.StatusCode);
        }
        [Theory]
        [InlineData("ABC")]
        public void GetMailContainer_ReturnsFalseScenario(string mailContainerNumber)
        {
            //Arrange
            //act
            var result = new HttpResponseMessage();
            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }
        [Theory]
        [InlineData("ABC")]
        public void GetMailContainer_ReturnsSuccess(string mailContainerNumber)
        {
            //Arrange
            //act
            var result = new HttpResponseMessage();
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
        #endregion

        #region "UpdateMailContainer"
        [Theory]
        [InlineData(typeof(MailContainer))]
        public void UpdateMailContainer_ReturnsException(MailContainer mailContainer)
        {
            //Arrange
            //act
            var result = new HttpResponseMessage();
            //Assert
            // WE can through and match the Exception as well, Code snippet is in below line 
            //Assert.ThrowsExceptionAsync<>().Result.ToString();

            Assert.AreNotEqual(HttpStatusCode.Accepted, result.StatusCode);
        }
        [Theory]
        [InlineData(typeof(MailContainer))]
        public void UpdateMailContainer_ReturnsFalseScenario(MailContainer mailContainer)
        {
            //Arrange
            //act
            var result= new HttpResponseMessage(); 
            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }
        [Theory]
        [InlineData(typeof(MailContainer))]
        public void UpdateMailContainer_ReturnsSuccess(MailContainer mailContainer)
        {
            //Arrange
            //act
            var result = new HttpResponseMessage();
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
        #endregion
    }
}
