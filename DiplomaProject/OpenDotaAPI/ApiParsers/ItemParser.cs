using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations;

namespace DiplomaProject.OpenDotaAPI.ApiParsers
{
    public class ItemParser : APIParser
    {
        public ItemParser(string json, ItemConfiguration conf) : base(json, conf)
        {
        }
        public override IAPIModel Parse()
        {
            var model = new ItemModel();
            var classType = model.GetType();
            var s = _configuration.Values["id"];
            string j = GetPropertyFromJson(_configuration.Values["id"]);
            string id =j;
            model = GetInfoAboutItem(id);
            return model;
        }
        private ItemModel GetInfoAboutItem(string id)
        {
            var conf = _configuration.Configuration.GetSection("prettyItems");
            var conf2 = conf.GetChildren();
            ItemModel model = new ItemModel();
            model.id = id;
            foreach (var item in conf2) {
                if (id == item.GetSection("id").Value) {
                   model.name = item.GetSection("name").Value;
                   model.path  = item.GetSection("path").Value;
                }
            }
            
            return model;
        }

    }
}
