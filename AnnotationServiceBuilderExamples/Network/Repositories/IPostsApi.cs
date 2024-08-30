using AnnotationServiceBuilder.Annotations.Refit;
using AnnotationServiceBuilderExamples.Data.Models;
using Refit;

namespace AnnotationServiceBuilderExamples.Network.Repositories
{
    [RefitClient]
    public interface IPostsApi
    {
        [Get("/posts")]
        Task<List<Post>> GetPostsAsync();

        [Get("/posts/{id}")]
        Task<Post> GetPostByIdAsync(int id);
    }
}
