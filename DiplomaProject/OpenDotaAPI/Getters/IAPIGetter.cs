using System.Net;

namespace DiplomaProject.OpenDotaAPI.Getters
{
    public interface IAPIGetter
    {
        public string Result { get; }
        public void Invoke();
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
