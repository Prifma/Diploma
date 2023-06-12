using DiplomaProject.DataBase.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace DiplomaProject.DataBase
{
    public class Tests
    {
        private DbContextOptions<ApplicationContext> GetOption() {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionstring = "server=localhost;user=root;password=;database=testdb;";
            var c = optionsBuilder.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)).Options;
            return c;
        }
        private Post GetMuckPost() {
            var post = new Post();
            post.Id = Guid.NewGuid();
            post.LikeCount = 5;
            post.DisCount = 1;
            post.Title = "Test";
            post.CreatetAt = DateTime.Now;
            post.Body = "Lorem Ipsum";
            post.UserId = "379206812";
            return post;
        }
        private Post GetMuckPost2()
        {
            var post = new Post();
            post.LikeCount = 8;
            post.DisCount = 100;
            post.Title = "TestChanged";
            post.CreatetAt = DateTime.Now;
            post.Body = "Lorem Ipsum2";
            post.UserId = "227037030";
            return post;
        }

        private Comment GetMuckComment() {
            var comment = new Comment();
            comment.Id = Guid.NewGuid();
            comment.UserId = "379206812";
            comment.Body = "Test";
            return comment;
        }
        private Comment GetMuckComment2()
        {
            var comment = new Comment();
            comment.Id = Guid.NewGuid();
            comment.UserId = "379206812";
            comment.Body = "TestChanget";
            return comment;
        }

        private Reaction GetMuckReaction()
        {
            var reaction = new Reaction();
            reaction.Id = Guid.NewGuid();
            reaction.Type = ReactionType.Like;
            reaction.UserId = 227037030;

            return reaction;
        }
        private Reaction GetMuckReaction2() {
            var reaction = new Reaction();
            reaction.Id = Guid.NewGuid();
            reaction.Type = ReactionType.Dislike;
            reaction.UserId = 227037030;
            return reaction;
        }


        [Fact]
        public void SubmitPostTest() {
            var post = GetMuckPost();
            var c = GetOption();

            using (var context = new ApplicationContext(c)) {
                var user = new ApplicationContextUser(context);
                user.SubmitPost(post);
                Post post2;
                post2 = user.GetPost(post.Id);
                Assert.Equal(post, post2);
                user.DeletePost(post.Id);
                var post3 = user.GetPost(post.Id);
                Assert.Null(post3);
            }
        }
        [Fact]
        public void SubmitCommentTest(){
            var post = GetMuckPost();
            var comment = GetMuckComment();
            comment.ParentPost = post;
            var c = GetOption();
            using (var context = new ApplicationContext(c))
            {
                var user = new ApplicationContextUser(context);
                user.SubmitPost(post);
                user.SubmitComment(comment);
                var comment1 = user.GetComment(comment.Id);
                Assert.Equal(comment, comment1);

                user.DeletePost(post.Id);
                var comment2 = user.GetComment(comment.Id);
                Assert.Null(comment2);
            }
        }
        [Fact]
        public void ChangePostTest() {
            var post = GetMuckPost();
            var c = GetOption();
            using (var context = new ApplicationContext(c))
            {
                var user = new ApplicationContextUser(context);
                user.SubmitPost(post);
                Post post2 = GetMuckPost2();
                post2.Id = post.Id;
                user.ChangePost(post.Id, post2);
                var post3 = user.GetPost(post.Id);
                Assert.Equal(post2.Title, post3.Title);
                Assert.Equal(post2.Body, post3.Body);
                user.DeletePost(post.Id);
                var post4 = user.GetPost(post.Id);
                Assert.Null(post4);
            }
        }
        [Fact]
        public void ChangeCommentTest()
        {
            var post = GetMuckPost();
            var comment = GetMuckComment();
            comment.ParentPost = post;
            var comment1 = GetMuckComment2();
            var c = GetOption();
            using (var context = new ApplicationContext(c))
            {
                var user = new ApplicationContextUser(context);
                user.SubmitPost(post);
                user.SubmitComment(comment);
                user.ChangeComment(comment.Id, comment1);
                var comment2 = user.GetComment(comment.Id);
                Assert.Equal(comment1.Body, comment2.Body);
                user.DeletePost(post.Id);
                var comment3 = user.GetComment(comment.Id);
                Assert.Null(comment3);
            }
        }
        [Fact]
        public void SubmitChildCommentTest() {
            var post = GetMuckPost();
            var comment = GetMuckComment();
            comment.ParentPost = post;
            var comment2 = GetMuckComment2();
            comment2.ParentPost = post;
            comment2.Parent = comment;
            var c = GetOption();
            using (var context = new ApplicationContext(c))
            {
                var user = new ApplicationContextUser(context);
                user.SubmitPost(post);
                user.SubmitComment(comment);
                user.SubmitComment(comment2);
                var comment1 = user.GetComment(comment2.Id);
                Assert.Equal(comment2, comment1);
                user.DeletePost(post.Id);
                var comment3 = user.GetComment(comment2.Id);
                Assert.Null(comment3);
            }
        }

        [Fact]
        public void AddReactionTest() {
            var r1 = GetMuckReaction();
            var r2 = GetMuckReaction2();
            var p = GetMuckPost();
            var com = GetMuckComment();
            com.ParentPost = p;
            var c = GetOption();
            using (var context = new ApplicationContext(c))
            {
                var user = new ApplicationContextUser(context);
                user.SubmitPost(p);
                user.SubmitComment(com);
                r1.EntityId = p.Id;
                user.SubmitReaction(r1);
                r2.EntityId = com.Id;
                user.SubmitReaction(r2);
                var r11 = user.GetReactions(p.Id);
                var r21 = user.GetReactions(com.Id);
                Assert.Equal(r11[0].EntityId, p.Id);
                Assert.Equal(r21[0].EntityId, com.Id);
                var p1 = user.GetPost(p.Id);
                var com1 = user.GetComment(com.Id);
                p = GetMuckPost();
                com = GetMuckComment();
                Assert.Equal(p.LikeCount, p1.LikeCount - 1);
                Assert.Equal(com.DisCount, com1.DisCount - 1);
                user.DeletePost(p1.Id);
            }
        }
        [Fact]
        public void DeleteReactionTest() {
            var r1 = GetMuckReaction();
            var r2 = GetMuckReaction2();
            var p = GetMuckPost();
            var com = GetMuckComment();
            com.ParentPost = p;
            var c = GetOption();
            using (var context = new ApplicationContext(c))
            {
                var user = new ApplicationContextUser(context);
                user.SubmitPost(p);
                user.SubmitComment(com);
                r1.EntityId = p.Id;

                user.SubmitReaction(r1);
                r2.EntityId = com.Id;
                user.SubmitReaction(r2);
                user.DeleteReaction(r1);
                user.DeleteReaction(r2);
                var r11 = user.GetReactions(p.Id);
                var r21 = user.GetReactions(com.Id);
                var p1 = user.GetPost(p.Id);
                var com1 = user.GetComment(com.Id);
                p = GetMuckPost();
                com = GetMuckComment();
                Assert.Equal(0,r11.Count);
                Assert.Equal(0,r21.Count);
                Assert.Equal(p.LikeCount, p1.LikeCount);
                Assert.Equal(com.DisCount, com1.DisCount);
                user.DeletePost(p1.Id);
            }
        }
        
    }
}
