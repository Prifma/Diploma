namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class MatchModel : IAPIModel
    {
        public string? matchId { get; set; }
        public HeroModel[] heroes { get; set; }
        public string? radiantWin { get; set; }
        public TeamModel dire { get; set; }
        public TeamModel radiant { get; set; }
        public string? duration { get; set; }
        //nullable
        public string? leagueId { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj is not MatchModel)
                return false;
            var model = obj as MatchModel;
            return this.matchId == model.matchId && this.radiantWin == model.radiantWin
                && this.duration == model.duration && this.leagueId == model.leagueId
                && this.dire == model.dire && this.radiant == model.radiant
                && CompareHeroes(this.heroes, model.heroes);
        }
        private bool CompareHeroes(HeroModel[] heroes1, HeroModel[] heroes2)
        {
            for (int i = 0; i < heroes1.Length; i++)
            {
                if (heroes1[i] != heroes2[i])
                    return false;
            }
            return true;
        }
    }
}
