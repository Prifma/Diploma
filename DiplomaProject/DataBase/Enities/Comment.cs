namespace DiplomaProject.DataBase.Enities
{
    public class Comment:BaseComunityEntity
    {
        public Guid? ParentId { get; set; }
        public Comment? Parent { get; set; }
        public Guid ParentPostId { get; set; }
        public Post? ParentPost { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is not Comment)
            {
                return false;
            }
            var c = obj as Comment;
            if (
                c.Id == Id &&
                c.Body == Body &&
                c.UserId == UserId &&
                c.Parent == c.Parent &&
                c.ParentPost == ParentPost
                )
                return true;
            return false;
        }
    }
}
