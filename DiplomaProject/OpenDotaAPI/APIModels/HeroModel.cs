using Microsoft.AspNetCore.Http.Features;

namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class HeroModel : IAPIModel
    {
        public string? heroId;
        public string? accountId;
        public string? netWorth;
        public string? playerSlot;
        public ItemModel[] mainItems = new ItemModel[6];
        public ItemModel[] backPackItems = new ItemModel[3];
        public ItemModel neutralItem = new ItemModel();
        public string? kills;
        public string? deaths;
        public string? assists;
        public string? goldPerMin;
        public string? epxPerMin;
        public string? heroDamage;
        public string? lastHits;
        public string? denies;
        public string? level;
        public string? towerDamage;
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj is not HeroModel)
                return false;
            var model = obj as HeroModel;
            return this.heroId == model.heroId && this.accountId == model.accountId
                && this.netWorth == model.netWorth && this.playerSlot == model.playerSlot
                && this.kills == model.kills && this.deaths == model.deaths
                && this.assists == model.assists && this.goldPerMin == model.goldPerMin
                && this.epxPerMin == model.epxPerMin && this.heroDamage == model.heroDamage
                && this.lastHits == model.lastHits && this.denies == model.denies
                && this.level == model.level && this.towerDamage == model.towerDamage
                && CompareItems(this.mainItems,model.mainItems) && CompareItems(this.backPackItems, model.backPackItems)
                && this.neutralItem == model.neutralItem;
        }

        private bool CompareItems(ItemModel[] items1, ItemModel[] items2) {
            for (int i = 0; i < items1.Length; i++) {
                if (items1[i] != items2[i])
                    return false;
            }
            return true;
        }

    }
}
