﻿using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SubscriptionService : ServiceBase, ISubscriptionService
    {
        public SubscriptionService(HttpClient httpClient) : base(httpClient)
        {

        }
        public SubscriptionService() : base(null)
        {

        }

        public SubscriptionService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
           
        }

        public SubscriptionService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<UnsubscribeResponse> Unsubscribe(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Subscription.Unsubscribe();
        }

        public async Task<SubscriptionResponse> Subscription(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Subscription.Get();
        }
    }
}
