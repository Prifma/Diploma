using DiplomaProject.OpenDotaAPI.APIModels;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations
{
    public abstract class APIParserConfiguration
    {
        public Dictionary<string,string> Values = new Dictionary<string,string>();
        protected IConfiguration _configuration;
        public IConfiguration Configuration { get { return _configuration; } }
        public APIParserConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
            AddDefault();
        }
        public void AddValue(string property, string path) {  Values.Add(property, path); }
        public void AddValue(Dictionary<string,string> values) {
            foreach (var value in values) {
                AddValue(value.Key, value.Value);
            }
        }
        protected virtual void AddDefault() {
            throw new NotImplementedException();
        }
        public virtual IAPIModel GetModel() { throw new NotImplementedException(); }
        public virtual APIParserConfiguration GetConfiguration(int id) { throw new NotImplementedException(); }
        public virtual APIParser GetParser(string json, APIParserConfiguration conf) {
            return new APIParser(json,conf);
        }
        
    }
}
