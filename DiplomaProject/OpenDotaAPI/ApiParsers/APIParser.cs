using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DiplomaProject.OpenDotaAPI.ApiParsers
{
    public class APIParser : IAPIParser
    {
        protected APIParserConfiguration _configuration;
        protected string _json;

        public virtual IAPIModel Parse()
        {
            var model = _configuration.GetModel();
            var classType = model.GetType();
            foreach (var item in _configuration.Values)
            {
                try
                {
                    var field = classType.GetProperty(item.Key);
                    if (field != null)
                    {
                        field.SetValue(model, GetPropertyFromJson(item.Value));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Fill(model);
            return model;
        }
        protected virtual void Fill(IAPIModel model) {

        }
        public APIParser(string json, APIParserConfiguration conf)
        {
            _configuration = conf;
            _json = json;
        }

        protected string? GetPropertyFromJson(string path) {
            try
            {
                var data = (JObject?)JsonConvert.DeserializeObject(_json);

                if (data == null)
                {
                    return null;
                }
                JToken? token = data.SelectToken(path);
                var result = token.Value<string>() ?? "";
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetPropertyFromArrayJson(path);

            }
        }
        private string? GetPropertyFromArrayJson(string path)
        {
            try
            {
                var data = (JArray?)JsonConvert.DeserializeObject(_json);

                if (data == null)
                {
                    return null;
                }
                JToken? token = data.SelectToken(path);
                var result = token.Value<string>() ?? "";
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public virtual IAPIModel[] ParseToArray() 
        {
            throw new NotImplementedException();
        }
    }
}
