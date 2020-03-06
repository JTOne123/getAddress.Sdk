﻿
namespace getAddress.Sdk.Api.Responses
{


    public abstract class ApiKeyResponse : ResponseBase<ApiKeyResponse.Success,ApiKeyResponse.Failed>
    {
        internal ApiKeyResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }


        public class Success : ApiKeyResponse
        {
            public string ApiKey { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, string apiKey) : base(statusCode, reasonPhrase, raw, true)
            {
                ApiKey = apiKey;
                SuccessfulResult = this;
            }
        }


        public class Failed : ApiKeyResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
