
# ![AnnotationServiceBuilder Icon](https://github.com/genryianchev/AnnotationServiceBuilder/raw/main/AnnotationServiceBuilder/icon.png) AnnotationServiceBuilderExamples

**AnnotationServiceBuilderExamples** is a repository containing example projects that demonstrate how to use the AnnotationServiceBuilder library. These examples cover various scenarios such as using Scoped, Singleton, and Transient services, as well as using Refit clients.

## Prerequisites

### Web Application

1. **.NET 6.0 or later**
2. **Visual Studio 2022** (or any other IDE with .NET support)

### Important Note

Ensure that your .NET SDK is up-to-date. This project requires .NET 6.0 or later.

## Project Structure

- **Data**: Contains data models and the `WeatherForecastService` for sample data generation.
- **Helpers**: Includes helper classes such as `SessionHelper` to manage user sessions.
- **Network**: Contains repositories and services for API interaction, including implementations of Refit clients.
- **Pages**: Blazor pages demonstrating different usage scenarios for the services.
- **Shared**: Shared components and layouts used across the Blazor pages.
- **wwwroot**: Static files like CSS, JavaScript, and images.

## Examples

Here are examples of how to use each annotation in your project:

### 1. Using Scoped Services

```csharp
using AnnotationServiceBuilder.Annotations.Scoped;
using AnnotationServiceBuilderExamples.Network.Repositories;

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
```

### 2. Using Singleton Services

```csharp
using AnnotationServiceBuilder.Annotations.Singleton;
using AnnotationServiceBuilderExamples.Data;

[SingletonService]
public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
    }
}
```

### 3. Using Transient Services

```csharp
using AnnotationServiceBuilder.Annotations.Transient_Services;
using AnnotationServiceBuilderExamples.Helpers;

[TransientService]
public class SessionHelper
{
    public string? UserId { get; set; }

    public void SetUserId(string userId)
    {
        UserId = userId;
    }
}
```

### 4. Example of a Refit Client

```csharp
using AnnotationServiceBuilder.Annotations.Refit;
using AnnotationServiceBuilder.Data.Models;
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
```

## Video Guides

For video guides on how to use AnnotationServiceBuilder, you can watch these YouTube videos:
- [AnnotationServiceBuilder Guide 1](https://www.youtube.com/watch?v=kofPf606OBE)
- [AnnotationServiceBuilder Guide 2](https://www.youtube.com/watch?v=tspUekM_UHg&t=3s)

## Additional Resources

- [AnnotationServiceBuilder Examples](https://github.com/genryianchev/AnnotationServiceBuilderExamples)
- [NuGet Package: AnnotationServiceBuilder](https://www.nuget.org/packages/AnnotationServiceBuilder)

## Running the Examples

1. Clone this repository:
   ```bash
   git clone https://github.com/genryianchev/AnnotationServiceBuilderExamples.git
   ```

2. Open the solution in Visual Studio 2022.

3. Set the startup project to `AnnotationServiceBuilderExamples`.

4. Run the application.

5. Navigate through the different pages to see the examples in action.

## Contributing

We welcome contributions! Please submit a pull request or open an issue to discuss your ideas or report bugs.

## License

This project is licensed under the MIT License.

```markdown
MIT License

Copyright (c) 2024 Gennadii Ianchev

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

---