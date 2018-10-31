// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.using Microsoft.AspNetCore.Authorization;

using System;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Authentication
{
    internal class JwtBearerOptionsConfiguration : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly IOptions<AzureADSchemeOptions> _schemeOptions;
        private readonly IOptionsMonitor<AzureADOptions> _azureADOptions;

        public JwtBearerOptionsConfiguration(
            IOptions<AzureADSchemeOptions> schemeOptions,
            IOptionsMonitor<AzureADOptions> azureADOptions)
        {
            _schemeOptions = schemeOptions;
            _azureADOptions = azureADOptions;
        }

        public void Configure(string name, JwtBearerOptions options)
        {
            var azureADScheme = GetAzureADScheme(name);
            var azureADOptions = _azureADOptions.Get(azureADScheme);
            if (name != azureADOptions.JwtBearerSchemeName)
            {
                return;
            }

            string audienceFormat = azureADOptions.Authority.Replace("{ClientId}", "{0}");
            options.Audience = string.Format(audienceFormat, azureADOptions.ClientId);

            string authorityFormat = azureADOptions.Authority.Replace("{Instance}", "{0}").Replace("{Tenant}", "{1}") ;
            options.Authority = string.Format(authorityFormat, azureADOptions.Instance, azureADOptions.Tenant);

        }

        public void Configure(JwtBearerOptions options)
        {
        }

        private string GetAzureADScheme(string name)
        {
            foreach (var mapping in _schemeOptions.Value.JwtBearerMappings)
            {
                if (mapping.Value.JwtBearerScheme == name)
                {
                    return mapping.Key;
                }
            }

            return null;
        }
    }
}
