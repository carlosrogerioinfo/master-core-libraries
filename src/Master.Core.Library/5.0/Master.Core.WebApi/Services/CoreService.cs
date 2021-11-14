using FluentValidator;
using Master.Core.WebApi.Extensions;
using Master.Core.WebApi.Response;
using System.Net.Http;

namespace Master.Core.WebApi.CoreServices
{
    public abstract class CoreService : Notifiable
    {
        protected virtual bool ResponseErrorHandling(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                case 400:
                    SetError(response);
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        protected virtual void SetError(HttpResponseMessage response)
        {
            var notifications = response.Content.ReadJsonAsync<ResponseError>("error").Result;
            AddNotification(notifications.Status.ToString(), notifications.Message);
        }
    }
}
