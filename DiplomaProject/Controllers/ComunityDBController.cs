using DiplomaProject.Controllers.DTO;
using DiplomaProject.DataBase;
using DiplomaProject.DataBase.Enities;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Controllers
{
    [ApiController]
    [Route("db")]
    public class ComunityDBController : ControllerBase
    {
        private ApplicationContextUser _db;
        public ComunityDBController(ApplicationContext context) {
            _db = new ApplicationContextUser(context);
        }
        [HttpGet]
        [Route("getPosts")]
        public List<Post> GetPosts(SortingType s = SortingType.Common,string search = "") {
            return _db.GetPosts(s,search);
        }
        [HttpGet]
        [Route("getPost")]
        public Post GetPost(Guid id)
        {
            return _db.GetPost(id);
        }
        [HttpPost]
        [Route("submitPost")]
        public void SubmitPost(Post post) {
            _db.SubmitPost(post);
        }
        [Route("submitComment")]
        [HttpPost]
        public void SubmitComment(Comment comment)
        {
            _db.SubmitComment(comment);
        }
        [HttpPost]
        [Route("submitChildComment")]
        public void SubmitComment(Guid parent, Guid parentComment)
        {
        }
        [HttpPost]
        [Route("changePost")]
        public void ChangePost(Post post) {
            _db.ChangePost(post.Id, post);
        }
        [HttpPost]
        [Route("changeComment")]
        public void ChangeComment(Comment comment)
        {
            _db.ChangeComment(comment.Id, comment);
        }
        [HttpPost]
        [Route("deleteComment")]
        public void DeleteComment(Guid commentId) {
            _db.DeleteComment(commentId);
        }
        [HttpPost]
        [Route("deletePost")]
        public void DeletePost(Guid postId) {
            _db.DeleteComment(postId);
        }
        [HttpPost]
        [Route("addReaction")]
        public void AddReaction(Reaction reaction) {
            Console.WriteLine(reaction.UserId);
            _db.ChangeReaction(reaction);
        }

        [HttpGet]
        [Route("checkReaction")]
        public object CheckReaction(long i, Guid e) {
            return _db.CheckReaction(i, e);
        }
        [HttpPost]
        [Route("banUser")]
        public void BanUser(UserID id) {
            _db.BanUser(id.Id);

        }
        [HttpPost]
        [Route("deleteEntity")]
        public void DeleteEntity(EntityID id) {
            _db.DeleteEntity(id.Id);
        }
        
    }
}
