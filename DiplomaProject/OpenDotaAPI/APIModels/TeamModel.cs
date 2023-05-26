namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class TeamModel : IAPIModel
    {
        public string? score;
        public ProInfoModel? proModel;
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj is not TeamModel)
                return false;
            var model = obj as TeamModel;
            return this.score == model.score && this.proModel == model.proModel;
        }
    }
}
