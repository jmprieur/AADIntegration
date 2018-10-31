﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Microsoft.AspNetCore.Authentication.AzureAD.UI
{
    /// <summary>
    /// Options for configuring authentication using Azure Active Directory.
    /// </summary>
    public class AzureADOptions
    {
        /// <summary>
        /// Gets or sets the OpenID Connect authentication scheme to use for authentication with this instance
        /// of Azure Active Directory authentication.
        /// </summary>
        public string OpenIdConnectSchemeName { get; set; } = OpenIdConnectDefaults.AuthenticationScheme;

        /// <summary>
        /// Gets or sets the Cookie authentication scheme to use for sign in with this instance of
        /// Azure Active Directory authentication.
        /// </summary>
        public string CookieSchemeName { get; set; } = CookieAuthenticationDefaults.AuthenticationScheme;

        /// <summary>
        /// Gets or sets the Jwt bearer authentication scheme to use for validating access tokens for this
        /// instance of Azure Active Directory Bearer authentication.
        /// </summary>
        public string JwtBearerSchemeName { get; internal set; }

        /// <summary>
        /// Gets or sets the client Id (Application Id) of the Azure AD application
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the audience for this Web Application or Web API (This audience needs
        /// to match the audience of the tokens sent to access this application)
        /// </summary>
        public string Audience { get; set; } = "api://{ClientId}";

        /// <summary>
        /// Gets or sets the client secret for the application
        /// </summary>
        /// <remarks>The client secret is only used if the Web app or Web API calls a Web
        /// API</remarks>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the tenant. The tenant can have one of the following values:
        /// <list type="table">
        /// <item><term>a tenant ID</term><description>A GUID representing the ID of the Azure Active Directory Tenant</description></item>
        /// <item><term>a domain</term><description>associated with Azure Active Directory</description></item>
        /// <item><term>common</term><description>if the <see cref="Authority"/> is Azure AD v2.0, enables to sign-in users from any
        /// Work and School account or Microsoft Personal Account. If Authority is Azure AD v1.0, enables sign-in from any Work and School accounts</description></item>
        /// <item><term>organizations</term><description>if the <see cref="Authority"/> is Azure AD v2.0, enables to sign-in users from any
        /// Work and School account</description></item>
        /// <item><term>consumers</term><description>if the <see cref="Authority"/> is Azure AD v2.0, enables to sign-in users from any
        /// Microsoft personal account</description></item>
        /// </list>
        /// </summary>
        public string Tenant { get; set; } = "common";

        /// <summary>
        /// Gets or sets the Azure Active Directory instance.
        /// </summary>
        public string Instance { get; set; } = "https://login.microsoftonline.com";

        /// <summary>
        /// Azure AD Authority.
        /// </summary>
        public string Authority { get; set; } = "https://{Instance}/{Tenant}/v2.0";

        /// <summary>
        /// Gets or sets the sign in callback path.
        /// </summary>
        public string CallbackPath { get; set; }

        /// <summary>
        /// Gets or sets the sign out callback path.
        /// </summary>
        public string SignedOutCallbackPath { get; set; }

        /// <summary>
        /// Gets all the underlying authentication schemes.
        /// </summary>
        public string[] AllSchemes => new[] { CookieSchemeName, OpenIdConnectSchemeName };
    }
}
