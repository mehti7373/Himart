﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;
public class JwtSettings
{
    public string Issuer { get; set; }
    public string SecretKey { get; set; }
    public int ExpirationMinutes { get; set; }
}
