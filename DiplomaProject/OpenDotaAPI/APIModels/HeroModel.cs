using Microsoft.AspNetCore.Http.Features;

namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class HeroModel : IAPIModel
    {
        public string? heroId { get; set; }
        public string? heroName { get; set; }
        public string? imgUrl { get; set; }
        public string? accountId { get; set; }
        public string? netWorth { get; set; }
        public string? playerSlot { get; set; }
        public ItemModel[] mainItems { get; set; } = new ItemModel[6];
        public ItemModel[] backPackItems { get; set; } = new ItemModel[3];
        public ItemModel neutralItem { get; set; } = new ItemModel();
        public string? kills { get; set; }
        public string? deaths { get; set; }
        public string? assists { get; set; }
        public string? goldPerMin { get; set; }
        public string? expPerMin { get; set; }
        public string? heroDamage { get; set; }
        public string? lastHits { get; set; }
        public string? denies { get; set; }
        public string? level { get; set; }
        public string? towerDamage { get; set; }
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
                && this.expPerMin == model.expPerMin && this.heroDamage == model.heroDamage
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
