﻿using AnnotationServiceBuilder.Data.Transient_Services;
using AnnotationServiceBuilderExamples.Helpers;

namespace AnnotationServiceBuilderExamples.Network
{
    [TransientService]
    class AuthHeaderHandler : DelegatingHandler
    {
        private readonly SessionHelper SessionHelper;

        public AuthHeaderHandler(SessionHelper SessionHelper)
        {
            this.SessionHelper = SessionHelper;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                SessionHelper.LoggedIn = false;
            }
            return response;
        }
    }
}
