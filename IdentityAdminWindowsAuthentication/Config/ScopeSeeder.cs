using System;
using System.Collections.Generic;

namespace IdentityAdminWindowsAuthentication.Config
{
    internal class ScopeSeeder
    {
        public static ICollection<InMemoryScope> Get(int limit)
        {
            var scopes = new HashSet<InMemoryScope>
            {
                new InMemoryScope{
                    Id = 1,
                    Name = "Admin",
                    Description = "They run the show"
                },
                new InMemoryScope{
                     Id = 2,
                    Name = "Manager",
                    Description = "They pay the bills"
                },
            };


            for (var i = 0; i < limit; i++)
            {
                var client = new InMemoryScope
                {
                    Name = GenName().ToLower(),
                    Description = GenName().ToLower(),
                    Id = scopes.Count + 1
                };

                scopes.Add(client);
            }

            return scopes;

        }

        private static string GenName()
        {
            var firstChar = (char)((Rnd.Next(26)) + 65);
            var username = firstChar.ToString();
            for (var j = 0; j < 6; j++)
            {
                username += char.ToLower((char)(Rnd.Next(26) + 65));
            }
            return username;
        }

        private static readonly Random Rnd = new Random();

    }
}
