using System.Collections.Generic;

namespace EcsRunner.Helpers
{
    class LevelsAssetsPath
    {
        public static readonly Dictionary<LevelTypes, string> LevelsPath = new Dictionary<LevelTypes, string>
        {
            {
                LevelTypes.FirstLevel, LevelsResourcesManager.FIRST_LEVEL_PATH
            }
        };
    }
}
