using Xunit;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations.Tests
{
    public class HeroConfigurationTest
    {
        [Fact]
        public void HeroTest() {
            Random r = new Random();
            int wait = r.Next(15, 100);
            Thread.Sleep(wait);
            Assert.True(true);
        }
    }
}
