﻿using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class AutocompletePostcodeResponse : ResponseBase<AutocompletePostcodeResponse.Success, AutocompletePostcodeResponse.Failed>
    {

        protected AutocompletePostcodeResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {


        }

        public class Success : AutocompletePostcodeResponse
        {
            public IEnumerable<PostcodePrediction> Predictions { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, IEnumerable<PostcodePrediction> predictions) : base(statusCode, reasonPhrase, raw, true)
            {
                this.SuccessfulResult = this;
                Predictions = predictions;
            }
        }

        public class Failed : AutocompletePostcodeResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }

}
