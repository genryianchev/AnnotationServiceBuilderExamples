using AnnotationServiceBuilder.Annotations.Patterns.CreationalDesignPatterns.Factory;
using AnnotationServiceBuilderExamples.Data.Models;

namespace AnnotationServiceBuilderExamples.Data.Patterns.Creational
{
    [FactoryPattern(typeof(IFactory<Post>))]
    public class PostFactory : IFactory<Post>
    {
        public Post Create()
        {
            return new Post();
        }
    }
}
