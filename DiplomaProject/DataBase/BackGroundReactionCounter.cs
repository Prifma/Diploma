using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomaProject.DataBase
{
    public class BackGroundReactionCounter : BackgroundService
    {
        private ILogger<BackGroundReactionCounter> _logger;
        private readonly IServiceProvider service;
        public BackGroundReactionCounter(ILogger<BackGroundReactionCounter> logger, IServiceProvider service)
        {
            _logger = logger;
            this.service = service;
            
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("хуй");
                using (var scope = service.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetService<ApplicationContext>();
                    _logger.LogInformation("Ітерація спрацювала");
                    var posts = _context.Posts.ToList();
                    foreach (var item in posts)
                    {
                        int likes = _context.Reactions.Where(r => r.EntityId == item.Id && r.Type == Enities.ReactionType.Like).Count();
                        int dislikes = _context.Reactions.Where(r => r.EntityId == item.Id && r.Type == Enities.ReactionType.Dislike).Count();
                        if (item.LikeCount != likes)
                        {
                            _logger.LogInformation("Неправильна кількість лайків");
                            item.LikeCount = likes;
                            _context.SaveChanges();
                        }
                        if (item.DisCount != dislikes)
                        {
                            _logger.LogInformation("Неправильна кількість дизлайків");
                            item.DisCount = dislikes;
                            _context.SaveChanges();
                        }

                    }
                }
                    await Task.Delay(10000,stoppingToken);
            }
        }
        private DbContextOptions<ApplicationContext> GetOption()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionstring = "server=localhost;user=root;password=;database=usersdb;";
            var c = optionsBuilder.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)).Options;
            return c;
        }
    }
}
