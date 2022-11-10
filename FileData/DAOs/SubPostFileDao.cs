/*using Application.DaoInterfaces;
using Domain;
using FileData;
using Shared.Models;

namespace FileData.DAOs {
    public class SubPostFileDao : ISubPostDao {

        private readonly FileContext _context;

        public SubPostFileDao(FileContext context)
        {
            _context = context;
        }

        public Task<SubPost> CreateAsync(SubPost subPost) {
            subPost.Posts = new List<Post>();

            _context.SubPosts.Add(subPost);
            _context.SaveChanges();

            return Task.FromResult(subPost);
        }

        public Task<IEnumerable<SubPost>> GetAsync() {
            IEnumerable<SubPost>  result = _context.SubPosts.AsEnumerable();
            return Task.FromResult(result);
        }
        
        public Task<SubPost?> GetByNameAsync(string name) {
            SubPost? subPage = _context.SubPosts.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(subPage);
        }

        public Task<IEnumerable<Post>?> GetPostsAsync(string subPostId) {
            IEnumerable<Post>? posts = _context.SubPosts.FirstOrDefault(t => t.Id.Equals(subPostId))?.Posts.AsEnumerable();
            return Task.FromResult(posts);
        }
    }
}*/