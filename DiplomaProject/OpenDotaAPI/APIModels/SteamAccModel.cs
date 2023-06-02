namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class SteamAccModel : IAPIModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string imgUrl { get; set; }
        public override string ToString()
        {
            return id+name+imgUrl;
        }
    }
}
