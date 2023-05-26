using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DiplomaProject.OpenDotaAPI.ApiParsers
{
    public class TotalsParser : APIParser
    {
        private int _index;
        public TotalsParser(string json, APIParserConfiguration conf, int index) : base(json, conf)
        {
            _index = index;
        }
        public override IAPIModel Parse()
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
                        field.SetValue(model, GetPropertyFromJson("[" + _index.ToString() + "]." + item.Value));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return model;
        }
        public override IAPIModel[] ParseToArray()
        {
            var data = (JArray?)JsonConvert.DeserializeObject(_json);
            var list = new List<TotalsModel>();
            if (data == null)
            {
                return new TotalsModel[0];
            }
            int i = 0;
            foreach (var item in data)
            {
                var conf = new AccountPartConfiguration(_configuration.Configuration, ((AccountPartConfiguration)_configuration).Section);
                var parser = new RecentMatchParser(_json, conf, i);
                list.Add((TotalsModel)parser.Parse());
                i++;
            }
            return list.ToArray();
        }
    }
}
