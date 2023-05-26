using DiplomaProject.OpenDotaAPI.APIModels;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations
{
    public class ItemConfiguration : APIParserConfiguration
    {
        private int _id;
        public ItemConfiguration(IConfiguration configuration,int index) : base(configuration)
        {
            _id = index;
        }
        public void setItemPosition(string section, int index=0) {
            if (index == -1) {
                var values = _configuration.GetSection("items:" + section);
                AddValue("id", $"players[{_id}]."+ values.Value);
                return;
            }
            var value = _configuration.GetSection("items").GetSection(section +$":{index}");
            AddValue("id", $"players[{_id}]." + value.Value);
        }
        protected override void AddDefault()
        {
            
        }
        public override IAPIModel GetModel()
        {
            return new ItemModel();
        }
    }
}
