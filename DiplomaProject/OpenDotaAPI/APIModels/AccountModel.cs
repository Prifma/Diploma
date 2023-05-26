using System.Runtime;

namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class AccountModel : IAPIModel
    {
        public ProfileModel profile { get; set; }
        public RecentMatchModel[] matches { get; set; }
        public TotalsModel[] totals { get; set; }
    }
}
