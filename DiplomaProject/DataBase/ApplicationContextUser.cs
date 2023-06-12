using DiplomaProject.Controllers.DTO;
using DiplomaProject.DataBase.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace DiplomaProject.DataBase
{
    public class ApplicationContextUser
    {
        private ApplicationContext _context;
        public ApplicationContextUser(ApplicationContext context) {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public List<Post> GetPosts(SortingType type,string search) {

            var preresult = _context.Posts.Where(p=>p.Title.Contains(search));
            IQueryable<Post> sortedResult;
            switch (type) {
                default:
                    sortedResult = preresult;
                    break;
                case SortingType.Like:
                    sortedResult = preresult.OrderByDescending(p => p.LikeCount);
                    break;
                case SortingType.Dislike:
                    sortedResult = preresult.OrderByDescending(p => p.DisCount);
                    break;
                case SortingType.Reaction:
                    sortedResult = preresult.OrderByDescending(p => p.DisCount + p.LikeCount);
                    break;
                case SortingType.Comment:
                    sortedResult = preresult.OrderByDescending(p => p.Comments.Count());
                    break;
                case SortingType.New:
                    sortedResult = preresult.OrderByDescending(p => p.CreatetAt);
                    break;
                case SortingType.Old:
                    sortedResult = preresult.OrderBy(p => p.CreatetAt);
                    break;
            }

            var result = sortedResult.Select(p=>new Post {Id = p.Id,Title = p.Title, UserId=p.UserId }).ToList();
            return result;
        }
        public Post? GetPost(Guid id) {
            var result = _context.Posts.Where(p => p.Id == id).Include(p =>p.Comments).FirstOrDefault();
            if(result is not null)
                result.CommentsCount = _context.Comments.Where(c => c.ParentPostId == result.Id).Count();
            return result;
        }

        public void SubmitPost(Post p) {
            p.CreatetAt = DateTime.Now;
            _context.Posts.Add(p);
            _context.SaveChanges();
        }
        public void DeletePost(Guid id)
        {
            var result = _context.Posts.Where(p => p.Id == id).FirstOrDefault();
            if (result is null)
                return;
            _context.Posts.Remove(result);
            
            _context.SaveChanges();
            var comments = _context.Comments.Where(c => c.ParentPostId == id);
            _context.Comments.RemoveRange(comments);
            _context.SaveChanges();
            
        }
        public void ChangePost(Guid id, Post post) {
            var result = _context.Posts.Where(p => p.Id == id).FirstOrDefault();
            if (result is null)
                return;
            result.Body = post.Body;
            result.Title = post.Title;
            _context.SaveChanges();
        }

        public Comment GetComment(Guid id) {
            var result = _context.Comments.Where(p => p.Id == id).FirstOrDefault();
            return result;
        }
        public void SubmitComment(Comment c) { 
            _context.Comments.Add(c);
            _context.SaveChanges();
        }
        public void DeleteComment(Guid id) {
            var result = _context.Comments.Where(p => p.Id == id).FirstOrDefault();
            if (result is null)
                return;
            _context.Comments.Remove(result);
            _context.SaveChanges();
        }
        public void ChangeComment(Guid id, Comment c) {
            var result = _context.Comments.Where(p => p.Id == id).FirstOrDefault();
            if (result is null)
                return;
            result.Body = c.Body;
            _context.SaveChanges();
        }
        public void SubmitReaction(Reaction r) {
            var post = _context.Posts.Where(p => p.Id == r.EntityId).FirstOrDefault();
            if (post is null) {
                var comment = _context.Comments.Where(c => c.Id == r.EntityId).FirstOrDefault();
                r.Entity = comment;
            }
            else r.Entity = post;
            if (r.Entity is null)
                throw new Exception("У реакції немає об'єкту");
            _context.Reactions.Add(r);
            if (r.Type == ReactionType.Like)
            {
                r.Entity.LikeCount++;
            }
            else if (r.Type == ReactionType.Dislike) {
                r.Entity.DisCount ++;
            }
            _context.SaveChanges();
        }
        public List<Reaction> GetReactions(Guid id) {
            var result = _context.Reactions.Where(r => r.EntityId == id).ToList();
            return result;
        }
        public void DeleteReaction(Reaction reac) {
            var reaction = _context.Reactions.Where(r => r.UserId == reac.UserId && r.EntityId == reac.EntityId).Include(r => r.Entity).FirstOrDefault();
            if (reaction is null) return;
            if (reaction.Type == ReactionType.Like)
            {
                reaction.Entity.LikeCount--;
            }
            else if (reaction.Type == ReactionType.Dislike)
            {
                reaction.Entity.DisCount--;
            }
            _context.Reactions.Remove(reaction);
            _context.SaveChanges();
        }
        public void ChangeReaction(Reaction r) {
            DeleteReaction(r);
            if (r.Type == ReactionType.None)
                return;
            SubmitReaction(r);
        }
        public object CheckReaction(long user, Guid entity) {
            var r = _context.Reactions.Where(r=> r.UserId == user && r.EntityId == entity).FirstOrDefault();
            
            if (r is null) {
                return false;
            }
            var result = new { isExist = r is not null, reactionType = r.Type };
            return result;
        }
        public void DeleteEntity(Guid id) { 
            var post = _context.Posts.Where(p => p.Id == id).FirstOrDefault();
            if (post is null) {
                var comment = _context.Comments.Where(c=> c.Id == id).FirstOrDefault();
                if(comment is null) { return; }
                DeleteComment(id);
                return;
            }
            DeletePost(id);
            return;
        }
        public void BanUser(string id) {
            var user = _context.Users.Where(u=> u.Id == id).FirstOrDefault();
            if (user is null) {
                var u = new User();
                u.Id = id;
                u.UserType = UserType.Banned;
                _context.Users.Add(u);
                var posts = _context.Posts.Where(p => p.UserId == id);
                foreach (var post in posts)
                {
                    _context.Posts.Remove(post);
                }
                var comments = _context.Comments.Where(p => p.UserId == id);
                foreach (var comment in comments) { 
                    _context.Comments.Remove(comment);
                }
                _context.SaveChanges();
            }
            Console.WriteLine(user is null);
        }
        
    }
}
