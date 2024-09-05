using AnnotationServiceBuilder.Annotations.Transient;

namespace AnnotationServiceBuilderExamples.Helpers
{
    [TransientService]
    public class SessionHelper
    {
        public bool LoggedIn { get; set; } = true;
    }
}
