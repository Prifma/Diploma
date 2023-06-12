namespace DiplomaProject.DataBase.Enities
{
    public class Reaction
    {
        public Guid? Id { get; set; }
        public Guid EntityId { get; set; }
        public BaseComunityEntity? Entity { get; set; }
        public ReactionType Type { get; set; }
        public long UserId { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is not Reaction)
            {
                return false;
            }
            var r = obj as Reaction;
            if (Id == r.Id && Entity == r.Entity && Type == r.Type)
                return true;
            return false;
        }
    }
}
