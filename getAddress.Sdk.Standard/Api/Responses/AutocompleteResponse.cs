﻿using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class AutocompleteResponse : ResponseBase<
        AutocompleteResponse.Success, 
        AutocompleteResponse.Failed, 
        AutocompleteResponse.TokenExpired,
        AutocompleteResponse.RateLimitedReached>
    {

        protected AutocompleteResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {


        }

        public class Success : AutocompleteResponse
        {
            public IEnumerable<Prediction> Predictions { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<Prediction> predictions) : base(statusCode, reasonPhrase, raw, true)
            {
                this.SuccessfulResult = this;
                Predictions = predictions;
            }
        }

        public class Failed : AutocompleteResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
            }

            internal static Failed NewFailed(int statusCode, string reasonPhrase, string raw)
            {
                return new Failed(statusCode, reasonPhrase, raw);
            }
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }
            internal static TokenExpired NewTokenExpired(string reasonPhrase, string raw)
            {
                return new TokenExpired(reasonPhrase, raw);
            }
        }

        public class RateLimitedReached : Failed
        {
            public double RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, double retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, double retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }
    }

}
