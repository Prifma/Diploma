using Xunit;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations.Tests
{
    public class MatchConfigurationTest
    {
        [Fact]
        public void MatchTest()
        {
            //TODO
            Random r = new Random();
            int wait = r.Next(15, 100);
            Thread.Sleep(wait);
            Assert.True(true);
        }
    }
}
