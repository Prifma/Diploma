namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class ProInfoModel:IAPIModel
    {
        public string? id;
        public string? name;
        public string? tag;
        public string? logoUrl;

        public override bool Equals(object? obj)
        {
            if(obj == null)
                return false;
            if(obj is not ProInfoModel)
                return false;
            var model = obj as ProInfoModel;
            return this.id == model.id && this.name == model.name && this.tag == model.tag && this.logoUrl == model.logoUrl;
        }
    }
}
