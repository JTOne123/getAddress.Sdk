﻿

namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveDomainWhitelistResponse : ResponseBase
    {

        protected RemoveDomainWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }


        public class Success : RemoveDomainWhitelistResponse
        {
            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, string message) : base(statusCode, reasonPhase, raw, true)
            {
                Message = message;
            }
        }

        public class Failed : RemoveDomainWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}