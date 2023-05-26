namespace DiplomaProject.OpenDotaAPI.APIModels
{
    public class ItemModel : IAPIModel
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? path { get; set; }
        public override bool Equals(object? obj1)
        {
            if (obj1 == null)
            {
                return false;
            }
            if ((obj1 is not ItemModel))
            {
                return false;
            }
            return (obj1 as ItemModel).id == this.id;
        }
        public override int GetHashCode()
        {
            return $"{this.id}{this.name}{this.path}".GetHashCode();
        }

    }
}
