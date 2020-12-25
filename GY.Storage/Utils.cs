using System.Linq;
using Rocket.API;
using Rocket.Core;
using Rocket.Unturned.Player;
using Steamworks;
using static GY.Storage.Storage;

namespace GY.Storage
{
    public static class Utils
    {
        public static StorageOption BestFit(UnturnedPlayer player)
        {
            var cfg = Instance.Configuration.Instance;
            
            if (player.IsAdmin && cfg.BestStorageForAdmin)
            {
                return cfg.StorageOptions.OrderBy(p => p.Height * p.Width).LastOrDefault();
            }
            
            var findPerms = cfg.StorageOptions.FindAll(p => player.GetPermissions().Select(s => s.Name).Contains(p.Permission));
            
            if (findPerms.Count == 0)
            {
                return null;
            }
            
            var best = findPerms.OrderBy(p => p.Height * p.Width).LastOrDefault();
            return best;
        }
        
    }
}