using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations;
using System.Xml.Serialization;

namespace DiplomaProject.OpenDotaAPI.ApiParsers
{
    public class HeroMatchParser : APIParser
    {
        public HeroMatchParser(string json, HeroConfiguratoin conf) : base(json, conf)
        {
        }
        

        protected override void Fill(IAPIModel model) {
            ((HeroModel)model).mainItems =  GetMainItems();
            ((HeroModel)model).backPackItems =  GetBackpackItems();
            ((HeroModel)model).neutralItem = GetNeutralItems();
        }

        private ItemModel[] GetMainItems() {
            string section = "main_items";
            var items = new ItemModel[6];
            for (int i = 0; i < 6; i++)
            {
                var itemconfig = new ItemConfiguration(_configuration.Configuration,((HeroConfiguratoin)_configuration).Index);
                itemconfig.setItemPosition(section,i);
                var parser = new ItemParser(_json, itemconfig);
                items[i]=(ItemModel)parser.Parse();
            }
            return items;
        }
        private ItemModel[] GetBackpackItems() {
            string section = "back_pack_items";
            var items = new ItemModel[3];
            for (int i = 0; i < 3; i++)
            {
                var itemconfig = new ItemConfiguration(_configuration.Configuration, ((HeroConfiguratoin)_configuration).Index);
                itemconfig.setItemPosition(section, i);
                var parser = new ItemParser(_json, itemconfig);
                items[i] = (ItemModel)parser.Parse();
            }
            return items;
        }
        private ItemModel GetNeutralItems() {
            string section = "neutral_item";
            var item = new ItemModel();
            var itemconfig = new ItemConfiguration(_configuration.Configuration, ((HeroConfiguratoin)_configuration).Index);
            itemconfig.setItemPosition(section,-1);
            var parser = new ItemParser(_json, itemconfig);
            item = (ItemModel)parser.Parse();
            return item;
        }
       public override IAPIModel[] ParseToArray()
       {
           HeroModel[] models = new HeroModel[10];
           for (int i = 0; i < models.Length; i++)
           {
               var conf = new HeroConfiguratoin(_configuration.Configuration, i);
               var parser = new HeroMatchParser(_json, conf);
               models[i] = (HeroModel)parser.Parse();
           }
           return models;
       }

    }
}
