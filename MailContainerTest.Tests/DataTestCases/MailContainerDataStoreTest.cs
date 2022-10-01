using Xunit;

namespace MailContainerTest.Tests.DataTestCases
{
   
    public class MailContainerDataStoreTest:IMailContainerDataStore
    {
        #region "GetMailContainer"
        [Theory]
        [InlineData("ABC")]
        public void GetMailContainer_ReturnsException(string mailContainerNumber)
        {
            //Arrange
            //act
            //Assert
            Assert.Contains("No Such Container Found");
        }
        [Theory]
        [InlineData("ABC")]
        public void GetMailContainer_ReturnsFalseScenario(string mailContainerNumber)
        {
            //Arrange
            //act
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
        [Theory]
        [InlineData("ABC")]
        public void GetMailContainer_ReturnsSuccess(string mailContainerNumber)
        {
            //Arrange
            //act
            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        #endregion

        #region "UpdateMailContainer"
        [Theory]
        [InlineData(typeof(MailContainer))]
        public void UpdateMailContainer_ReturnsException(MailContainer mailContainer)
        {
            //Arrange
            //act
            //Assert
            Assert.Contains("No Such Container Found");
        }
        [Theory]
        [InlineData(typeof(MailContainer))]
        public void UpdateMailContainer_ReturnsFalseScenario(MailContainer mailContainer)
        {
            //Arrange
            //act
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
        [Theory]
        [InlineData(typeof(MailContainer))]
        public void UpdateMailContainer_ReturnsSuccess(MailContainer mailContainer)
        {
            //Arrange
            //act
            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        #endregion
    }
}
