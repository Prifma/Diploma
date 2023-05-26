namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class MatchModel : IAPIModel
    {
        public string? matchId;
        public HeroModel[] heroes = new HeroModel[10];
        public string? radiantWin;
        public TeamModel dire;
        public TeamModel radiant;
        public string? duration;
        //nullable
        public string? leagueId;
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
