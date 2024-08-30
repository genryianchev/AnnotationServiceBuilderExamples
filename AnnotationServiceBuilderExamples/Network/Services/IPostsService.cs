using AnnotationServiceBuilderExamples.Data.Models;

namespace AnnotationServiceBuilderExamples.Network.Services
{

    public interface IPostsService
    {
        Task<List<Post>> GetPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
    }
}
