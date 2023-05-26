using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DiplomaProject.OpenDotaAPI.APIModels;
using static System.Net.Mime.MediaTypeNames;

namespace DiplomaProject.BackWorkers
{
    public class BackWorkerItems
    {
        public void Start(IConfiguration configuration) {
            var data = (JObject)Serialize(configuration.GetSection("items_info"));
            List<ItemModel> items = new List<ItemModel>();
            foreach (var item in data)
            {
                var semiData = (JObject?)JsonConvert.DeserializeObject(item.Value.ToString());

                var i = new ItemModel();
                i.id = semiData.SelectToken("id").Value<string>() ;
                if (semiData.SelectToken("dname") == null) continue;
                i.name = semiData.SelectToken("dname").Value<string>();
                i.path = "https://cdn.cloudflare.steamstatic.com/" + semiData.SelectToken("img").Value<string>();
                items.Add(i);
            }
            SaveAsFile(items);
        }
        public JToken Serialize(IConfiguration config)
        {
            JObject obj = new JObject();
            foreach (var child in config.GetChildren())
            {
                obj.Add(child.Key, Serialize(child));
            }

            if (!obj.HasValues && config is IConfigurationSection section)
                return new JValue(section.Value);

            return obj;
        }
        private void SaveAsFile(List<ItemModel> items) {
            using (StreamWriter file = File.CreateText("./prettyItem.json"))
            {   
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, items);
            }
        }
    }
}
