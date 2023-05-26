using Xunit;

namespace DiplomaProject.OpenDotaAPI.Getters
{
    public class ApiGetterTest
    {
        [Fact]
        public void GetTest()
        {
            string testurl = "https://api.opendota.com/api";
            OnceApiGetter getter = new OnceApiGetter(testurl);

            getter.Invoke();

            Assert.True(getter.Result.Length > 4);
        }
    }
}
