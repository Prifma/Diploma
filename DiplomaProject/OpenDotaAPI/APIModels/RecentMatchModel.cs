namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class RecentMatchModel : IAPIModel
    {
        public string matchId;
        public string playerSlot;
        public string radiantWin;
        public string heroId;
        public string kills;
        public string deaths;
        public string assists;
    }
}