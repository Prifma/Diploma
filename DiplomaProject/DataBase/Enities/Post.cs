using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaProject.DataBase.Enities
{
    public class Post:BaseComunityEntity
    {
        public string? Title { get; set; }
        public DateTime CreatetAt { get; set; }
        public List<Comment>? Comments { get; set; }
        [NotMapped]
        public int CommentsCount { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is not Post) {
                return false;
            }
            var post = obj as Post;
            if (
                post.Id == Id &&
                post.UserId == UserId &&
                post.Body == Body &&
                post.Title == Title &&
                post.LikeCount == LikeCount &&
                post.DisCount == DisCount &&
                post.CreatetAt.Date == CreatetAt.Date &&
                post.CreatetAt.Hour == CreatetAt.Hour &&
                post.CreatetAt.Minute == CreatetAt.Minute &&
                post.Comments.Count == Comments.Count
                ) 
            {
                for (int i = 0; i < Comments.Count; i++) {
                    if (Comments[i] == post.Comments[i])
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
