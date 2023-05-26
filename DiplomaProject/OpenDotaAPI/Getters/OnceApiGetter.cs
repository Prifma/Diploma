using System.Net;

namespace DiplomaProject.OpenDotaAPI.Getters
{
    public class OnceApiGetter : APIGetter
    {
        private string? _result;
        private string _url;
        public string Result => _result ?? "";
        public OnceApiGetter(string url)
        {
            _url = url;
        }

        public void Invoke()
        {
            _result = Get(_url);
        }


    }
}
