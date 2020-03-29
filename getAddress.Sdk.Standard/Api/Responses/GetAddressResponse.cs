﻿using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class GetAddressResponse : ResponseBase<GetAddressResponse.Success,GetAddressResponse.Failed,GetAddressResponse.TokenExpired>
    {
        protected GetAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

            
        }

        public AccountExpired AccountExpiredResult { get; private set; }

        public bool TryGetExpired(out AccountExpired accountExpiredResult)
        {
            if (IsExpired)
            {
                accountExpiredResult = AccountExpiredResult;
                return true;
            }

            accountExpiredResult = default;
            return false;
        }

        public bool IsExpired { get; private set; }
        

        public class Success : GetAddressResponse
        {
            public IEnumerable<Address> Addresses { get; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, double latitude, double longitude, IEnumerable<Address> addresses) : base(statusCode, reasonPhrase, raw, true)
            {
                Latitude = latitude;
                Longitude = longitude;
                Addresses = addresses;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetAddressResponse 
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
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

        public class AccountExpired : Failed
        {
            public AccountExpired(string reasonPhrase, string raw) : base(400, reasonPhrase, raw)
            {
                AccountExpiredResult = this;
                IsExpired = true;
            }
        }
    }
}
