﻿using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListSecondLimitReachedWebhookResponse: ResponseBase<ListSecondLimitReachedWebhookResponse.Success,
        ListSecondLimitReachedWebhookResponse.Failed, ListSecondLimitReachedWebhookResponse.TokenExpired>
    {
        protected ListSecondLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        
        }

        public class Success: ListSecondLimitReachedWebhookResponse
        {
            public IEnumerable<SecondLimitReachedWebhook> Webhooks { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<SecondLimitReachedWebhook> webhooks) :base(statusCode, reasonPhrase, raw,true)
            {
                Webhooks = webhooks;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListSecondLimitReachedWebhookResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) :base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }
        }
    }
}
