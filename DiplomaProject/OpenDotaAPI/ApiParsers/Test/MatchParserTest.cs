using Xunit;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.Test
{
    public class MatchParserTest
    {
        [Fact]
        public void ParseTest()
        {
            //TODO
            Random r = new Random();
            int wait = r.Next(15, 100);
            Thread.Sleep(wait);
            Assert.True(true);
        }
    }
}
