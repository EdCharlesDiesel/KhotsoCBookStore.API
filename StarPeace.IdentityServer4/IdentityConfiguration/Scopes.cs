using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.IdentityServer4.IdentityConfiguration
{
    public class Scopes
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("khotsoCBookStoreApi.read", "Read Access to KhotsoCBookStore API"),
                new ApiScope("khotsoCBookStoreApi.write", "Write Access to KhotsoCBookStore API"),
            };
        }
    }
}
