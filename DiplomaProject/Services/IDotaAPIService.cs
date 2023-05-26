using DiplomaProject.OpenDotaAPI.APIModels;

namespace DiplomaProject.Services
{
    public interface IDotaAPIService
    {
        public IAPIModel GetMacth(long id);
        public IAPIModel GetMacth1(long id);
        public IAPIModel GetAccountInfo(long id);
    }
}
