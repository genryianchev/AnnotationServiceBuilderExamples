using AnnotationServiceBuilder.Annotations.Patterns.CreationalDesignPatterns.Factory;
using AnnotationServiceBuilder.Annotations.Transient;
using AnnotationServiceBuilderExamples.Data.Models;

namespace AnnotationServiceBuilderExamples.Data.Services
{
    [TransientService]
    public class PostFactoryService
    {
        private readonly IFactory<Post> _postFactory;

        public PostFactoryService(IFactory<Post> postFactory)
        {
            _postFactory = postFactory;
        }

        public Post CreateNewPost(int id, string title, string body)
        {
            var post = _postFactory.Create();
            post.Id = id;
            post.Title = title;
            post.Body = body;
            return post;
        }
    }
}
