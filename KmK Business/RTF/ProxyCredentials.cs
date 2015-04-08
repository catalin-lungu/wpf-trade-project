﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace KmK_Business.RTF
{
    public class ProxyCredentials : ICredentialPolicy
    {
        bool ICredentialPolicy.ShouldSendCredential(Uri challengeUri, WebRequest request, NetworkCredential credential, IAuthenticationModule authenticationModule)
        {
            return true;
        }
    }
}
