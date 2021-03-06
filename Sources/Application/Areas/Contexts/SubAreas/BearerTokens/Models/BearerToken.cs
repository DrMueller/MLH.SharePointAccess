﻿using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.BearerTokens.Models
{
    internal class BearerToken
    {
        public string AccessToken { get; }
        public string Resource { get; }
        public DateTime UtcExpiresOn { get; }

        public BearerToken(DateTime utcExpiresOn, string resource, string accessToken)
        {
            Guard.StringNotNullOrEmpty(() => resource);
            Guard.StringNotNullOrEmpty(() => accessToken);

            UtcExpiresOn = utcExpiresOn;
            Resource = resource;
            AccessToken = accessToken;
        }
    }
}