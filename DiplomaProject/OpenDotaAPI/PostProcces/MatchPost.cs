using DiplomaProject.OpenDotaAPI.APIModels;

namespace DiplomaProject.OpenDotaAPI.PostProcces
{
    public class MatchPost
    {
        public MatchPost() { }
        public void SetNormalDuration(MatchModel model) {
            if (model.duration == null) return;
           long t = long.Parse(model.duration);
            var a = TimeSpan.FromSeconds(t);
            model.duration = a.ToString(@"mm\:ss");
        }
    }
}
