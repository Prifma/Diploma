namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class RecentMatchModel : IAPIModel
    {
        public string matchId { get; set; }
        public string playerSlot { get; set; }
        public string radiantWin { get; set; }
        public string heroId { get; set; }
        public string kills { get; set; }
        public string deaths { get; set; }
        public string assists { get; set; }
    }
}