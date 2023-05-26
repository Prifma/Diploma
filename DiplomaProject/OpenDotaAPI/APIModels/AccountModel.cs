using System.Runtime;

namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class AccountModel : IAPIModel
    {
        public ProfileModel profile;
        public RecentMatchModel[] matches;
        public TotalsModel[] totals;
    }
}
