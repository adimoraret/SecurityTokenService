using System;
using System.Collections.Generic;

namespace IdentityAdminWindowsAuthentication.Config
{
    internal class InMemoryScope
    {
        public InMemoryScope()
        {
            ScopeClaims = new List<InMemoryScopeClaim>();
            ScopeSecrets = new List<InMemoryScopeSecret>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClaimsRule { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public bool Emphasize { get; set; }
        public bool Enabled { get; set; }
        public bool IncludeAllClaimsForUser { get; set; }
        public bool Required { get; set; }
        public ICollection<InMemoryScopeClaim> ScopeClaims { get; set; }
        public ICollection<InMemoryScopeSecret> ScopeSecrets { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public int Type { get; set; }

        public bool AllowUnrestrictedIntrospection { get; set; }
    }

    public class InMemoryScopeClaim
    {
        public bool AlwaysIncludeInIdToken { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class InMemoryScopeSecret
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }
        public virtual string Value { get; set; }
    }
}
