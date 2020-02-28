using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.BearerTokens.Models;
using Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.Environments.Models;
using Mmu.Mlh.SharePointAccess.Infrastructure.Settings.Services;
using Newtonsoft.Json.Linq;

namespace Mmu.Mlh.SharePointAccess.Areas.Contexts.SubAreas.BearerTokens.Services.Implementation
{
    internal class BearerTokenFactory : IBearerTokenFactory
    {
        private readonly ISpSettingsProvider _spSettingsProvider;

        public BearerTokenFactory(ISpSettingsProvider spSettingsProvider)
        {
            _spSettingsProvider = spSettingsProvider;
        }

        public async Task<BearerToken> CreateAsync(SpEnvironment spEnvironment)
        {
            var requestUrl = "https://accounts.accesscontrol.windows.net/" + spEnvironment.TenantId + "/tokens/OAuth/2";
            var restRequest = new HttpRequestMessage(HttpMethod.Post, requestUrl);

            AppendContent(restRequest, spEnvironment);

            using var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(restRequest);
            var content = await response.Content.ReadAsStringAsync();
            return ParseBearerToken(content);
        }

        private static BearerToken ParseBearerToken(string content)
        {
            var dynamicObject = JObject.Parse(content);
            var expiresIn = dynamicObject.Value<long>("expires_in");
            var expiresInHours = expiresIn / 60 / 60;
            var expiresInUtc = DateTime.UtcNow.AddHours(expiresInHours);

            return new BearerToken(
                expiresInUtc,
                dynamicObject.Value<string>("resource"),
                dynamicObject.Value<string>("access_token"));
        }

        private void AppendContent(HttpRequestMessage req, SpEnvironment spEnvironment)
        {
            const string GrantTypeClientCredentials = "client_credentials";
            var securitySettings = _spSettingsProvider.Settings.Security;
            var completeClientId = $"{securitySettings.ClientId}@{spEnvironment.TenantId}";

            var requestParameters = new Dictionary<string, string>
            {
                { "grant_type", GrantTypeClientCredentials },
                { "client_id", completeClientId },
                { "client_secret", securitySettings.ClientSecret },
                { "resource", spEnvironment.ResourceIdentifier }
            };

            var stringBuilder = new StringBuilder();

            foreach (var(key, value) in requestParameters)
            {
                if (stringBuilder.Length != 0)
                {
                    stringBuilder.Append("&");
                }

                stringBuilder.AppendFormat("{0}{1}{2}", HttpUtility.UrlEncode(key), "=", HttpUtility.UrlEncode(value));
            }

            var sb = stringBuilder.ToString();

            req.Content = new StringContent(sb);
            req.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        }
    }
}