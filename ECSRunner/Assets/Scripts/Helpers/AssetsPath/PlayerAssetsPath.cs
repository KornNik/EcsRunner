using System.Collections.Generic;

namespace EcsRunner.Helpers
{
    class PlayerAssetsPath
    {
        public static readonly Dictionary<PlayerTypes, string> PlayersPath = new Dictionary<PlayerTypes, string>
        {
            {
                PlayerTypes.PlayerOne, PlayerResourcesManager.PLAYER_PATH
            }
        };
    }
}
