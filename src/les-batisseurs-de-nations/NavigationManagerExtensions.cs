using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components
{
    public static class NavigationManagerExtensions
    {
        public static bool IsLocalHost(this NavigationManager navigationManager)
        {
            return navigationManager.Uri.StartsWith("https://localhost", StringComparison.OrdinalIgnoreCase);
        }

        public static string TwitchEmbedParent(this NavigationManager navigationManager)
        {
            var parent = navigationManager.IsLocalHost() ? "localhost" : "les-batisseurs-de-nations.rpg.solutions";
            return parent;
        }
    }
}
