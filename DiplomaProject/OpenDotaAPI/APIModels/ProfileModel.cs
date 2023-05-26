namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class ProfileModel : IAPIModel
    {
        public string rankTier { get; set; }
        public string accountId { get; set; }
        public string personaName { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string profileUrl { get; set; }
        public string isSubscriber { get; set; }
        public string leaderBordRank { get; set; }
    }
}