using DiplomaProject.OpenDotaAPI.APIModels;
using System;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations
{
    public class HeroConfiguratoin : APIParserConfiguration
    {
        private int _index;
        public int Index { get { return _index; } }
        public HeroConfiguratoin(IConfiguration configuration, int index) : base(configuration)
        {
            _index = index;
            Dictionary<string, string>? values = _configuration.GetSection("heroes").
                                                  GetChildren().ToDictionary(x => x.Key, x => $"players[{Index}]." + x.Value);
            AddValue(values);
        }

        protected override void AddDefault()
        {
            
        }
        public override IAPIModel GetModel()
        {
            return new HeroModel();
        }
    }
}
