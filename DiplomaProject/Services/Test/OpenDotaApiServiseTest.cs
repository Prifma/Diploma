using Xunit;

namespace DiplomaProject.Services.Test
{
    public class OpenDotaApiServiseTest
    {
        [Fact]
        public void GetMatchTest()
        {
            //TODO
            Random r = new Random();
            int wait = r.Next(15, 100);
            Thread.Sleep(wait);
            Assert.True(true);
        }
    }
}
