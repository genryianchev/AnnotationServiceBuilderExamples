﻿using AnnotationServiceBuilder.Annotations.Scoped;
using AnnotationServiceBuilderExamples.Data.Models;

namespace AnnotationServiceBuilderExamples.Network.Repositories.Impl
{
    [ScopedService(typeof(IPostsRepository))]
    public class PostsRepository : IPostsRepository
    {
        private readonly IPostsApi _postsApi;

        public PostsRepository(IPostsApi postsApi)
        {
            _postsApi = postsApi;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _postsApi.GetPostsAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postsApi.GetPostByIdAsync(id);
        }
    }
}
