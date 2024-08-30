using AnnotationServiceBuilderExamples.Data.Models;

namespace AnnotationServiceBuilderExamples.Network.Repositories
{
    public interface IPostsRepository
    {
        Task<List<Post>> GetPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
    }
}
