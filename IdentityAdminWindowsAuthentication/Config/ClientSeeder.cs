using System;
using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdentityAdminWindowsAuthentication.Config
{
    internal class ClientSeeder
    {
        public static HashSet<InMemoryClient> Get(int limit)
        {
            var clients = new HashSet<InMemoryClient>
            {
                new InMemoryClient{
                    ClientId = "IdentityAdminClientUniqueId",
                    ClientName = "Indentity Admin Client",
                    Enabled = true,
                    Flow = Flows.Implicit,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    AllowedScopes = new List<InMemoryClientScope>
                    {
                        new InMemoryClientScope
                        {
                            Id = 1,
                            Scope =  "openid",
                        },
                        new InMemoryClientScope
                        {
                            Id = 2,
                            Scope =  "profile",
                        },
                        new InMemoryClientScope
                        {
                            Id = 3,
                            Scope =  "email",
                        },
                    },
                    AccessTokenType = AccessTokenType.Jwt
                }
            };

            for (var i = 0; i < limit; i++)
            {
                var client = new InMemoryClient
                {
                    ClientName = GenName().ToLower(),
                    ClientId = GenName().ToLower(),
                    Id = clients.Count + 1,

                };

                clients.Add(client);
            }

            return clients;
        }

        private static string GenName()
        {
            var firstChar = (char)((Rnd.Next(26)) + 65);
            var username = firstChar.ToString();
            for (var j = 0; j < 6; j++)
            {
                username += Char.ToLower((char)(Rnd.Next(26) + 65));
            }
            return username;
        }

        private static readonly Random Rnd = new Random();
    }
}
