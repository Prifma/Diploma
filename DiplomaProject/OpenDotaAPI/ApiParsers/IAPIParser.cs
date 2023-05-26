using DiplomaProject.OpenDotaAPI.APIModels;

namespace DiplomaProject.OpenDotaAPI.ApiParsers
{
    public interface IAPIParser
    {
        public IAPIModel Parse();
        public IAPIModel[] ParseToArray();
        
    }
}
