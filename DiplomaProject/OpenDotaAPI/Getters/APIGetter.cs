using System.Net;

namespace DiplomaProject.OpenDotaAPI.Getters
{
    public abstract class APIGetter : IAPIGetter
    {
        public string Result => throw new NotImplementedException();

        public void Invoke()
        {
            throw new NotImplementedException();
        }
        protected string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex) { return ""; }

        }
    }
}
