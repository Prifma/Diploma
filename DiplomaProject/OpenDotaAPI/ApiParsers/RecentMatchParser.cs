using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DiplomaProject.OpenDotaAPI.ApiParsers
{
    public class RecentMatchParser : APIParser
    {
        private int _index;
        public RecentMatchParser(string json, AccountPartConfiguration conf,int index) : base(json, conf)
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
                        field.SetValue(model, GetPropertyFromJson("[" +_index.ToString() + "]." + item.Value));
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
        protected override void Fill(IAPIModel model)
        {
            var recent = (RecentMatchModel)model;
            var heroes = _configuration.Configuration.GetSection("heroesInfo").GetChildren();
            var hero = heroes.Where(h => h.GetSection("id").Value == recent.heroId).FirstOrDefault();

            if (hero is not null)
            {
                recent.heroName = hero.GetSection("localized_name").Value;
                recent.imgUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/" + hero.GetSection("name").Value + ".png";
            }
        }


        public override IAPIModel[] ParseToArray()
        {
            var data = (JArray?)JsonConvert.DeserializeObject(_json);
            var list = new List<RecentMatchModel>();
            if (data == null)
            {
                return new RecentMatchModel[0];
            }
            int i = 0;
            foreach (var item in data) {
                var conf = new AccountPartConfiguration(_configuration.Configuration, ((AccountPartConfiguration)_configuration).Section);
                var parser = new RecentMatchParser(_json, conf,i);
                list.Add((RecentMatchModel)parser.Parse());
                i++;
            }
            return list.ToArray();
        }

    }
}
