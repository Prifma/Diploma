using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers;
using DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations;
using DiplomaProject.OpenDotaAPI.APIComposite;

namespace DiplomaProject.OpenDotaAPI.Fabrics
{
    public class APIParserFactory
    {
        private IConfiguration _configuration;
        public APIParserFactory(IConfiguration configuration) {
               _configuration = configuration;
        }
        public Component GetMatch(string _json) {
            MatchModel m = new MatchModel();
            ProInfoConfiguration c = new ProInfoConfiguration(_configuration, "radiant");
            var parser = new APIParser(_json,c);
            Leaf component = new Leaf(typeof(TeamModel).GetField("proModel"),new ProInfoModel(),parser);
            ProInfoConfiguration c1 = new ProInfoConfiguration(_configuration, "dire");
            var parser1 = new APIParser(_json, c);
            Leaf component1 = new Leaf(typeof(TeamModel).GetField("proModel"), new ProInfoModel(), parser);
            TeamConfiguration c2 = new TeamConfiguration(_configuration,true);
            var parser2 = new APIParser(_json, c2);
            Composite component2 = new Composite(typeof(MatchModel).GetField("radiant"), new TeamModel(), parser2);
            component2.Add(component);
            TeamConfiguration c3 = new TeamConfiguration(_configuration, false);
            var parser3 = new APIParser(_json, c3);
            Composite component3 = new Composite(typeof(MatchModel).GetField("dire"), new TeamModel(), parser3);
            component3.Add(component1);
            MatchConfiguration c4 = new MatchConfiguration(_configuration);
            c4.AddPro();
            APIParser parser4 = new APIParser(_json, c4);
            Composite composite = new Composite( new MatchModel(), parser4);
            composite.Add(component2);
            composite.Add(component3);
            HeroMatchParser parser5 = new HeroMatchParser(_json,new HeroConfiguratoin(_configuration,-1));
            LeafArray leaf = new LeafArray(typeof(MatchModel).GetField("heroes"), new IAPIModel[10], parser5);
            composite.Add(leaf);
            return composite;
        }
    }
}

//2641 доставка на полігон
