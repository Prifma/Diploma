namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class ProInfoModel:IAPIModel
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? tag { get; set; }
        public string? logoUrl { get; set; }

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
