using DiplomaProject.OpenDotaAPI.APIModels;

namespace DiplomaProject.Services
{
    public interface IDotaAPIService
    {
        public IAPIModel GetMacth(long id);
        public IAPIModel GetAccountInfo(long id);
        public IAPIModel[] GetRecentMatch(long id);
        public IAPIModel[] GetTotals(long id);
        public SteamAccModel GetSteamAcc(long id);

    }
}
