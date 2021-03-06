// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using static System.Diagnostics.Debug;
using static System.Text.Encoding;
using static IdentityModel.Base64Url;
using static Newtonsoft.Json.JsonConvert;

namespace IdentityServerHost.Quickstart.UI
{
    public class DiagnosticsViewModel
    {
        public DiagnosticsViewModel(AuthenticateResult result)
        {
            AuthenticateResult = result;

            Assert(result.Properties != null, "result.Properties != null");
            if (result.Properties.Items.ContainsKey("client_list"))
            {
                var encoded = result.Properties.Items["client_list"];
                var bytes = Decode(encoded);
                var value = UTF8.GetString(bytes);
                Clients = DeserializeObject<string[]>(value);
            }
        }

        public AuthenticateResult AuthenticateResult { get; }
        public IEnumerable<string> Clients { get; } = new List<string>();
    }
}