namespace DiplomaProject.DataBase.Enities
{
    public class BaseComunityEntity
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public int LikeCount { get; set; }
        public int DisCount { get; set; }
    }
}
