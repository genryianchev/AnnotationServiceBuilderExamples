using AnnotationServiceBuilder.Data.Transient_Services;

namespace AnnotationServiceBuilderExamples.Helpers
{
    [TransientService]
    public class SessionHelper
    {
        public bool LoggedIn { get; set; } = true;
    }
}
