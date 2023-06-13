using DiplomaProject.DataBase.Enities;

namespace DiplomaProject.Controllers.DTO
{
    public class Posts
    {
        public List<Post> posts { get; set; }
        public int page { get; set; }
        public int pagesCount { get; set; }
        public string pageSearch { get; set; }
        public SortingType pageSort { get; set; }
    }
}
