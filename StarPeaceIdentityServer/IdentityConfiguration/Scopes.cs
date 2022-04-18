using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceIdentityServer.IdentityConfiguration
{
    public class Scopes
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("khotsoCBookStoreApi.read", "Read Access to khotsoCBookStore API"),
                new ApiScope("khotsoCBookStoreApi.write", "Write Access to khotsoCBookStore API"),
            };
        }
    }
}
