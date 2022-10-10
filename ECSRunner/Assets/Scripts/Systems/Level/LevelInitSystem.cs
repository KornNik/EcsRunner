using UnityEngine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using EcsRunner.Data;
using EcsRunner.Helpers;
using EcsRunner.Components;

namespace EcsRunner.Systems
{
    class LevelInitSystem : IEcsInitSystem
    {
        private readonly EcsWorldInject _world = default;

        private readonly EcsSharedInject<GameData> _sharedInject = default;

        private readonly EcsPoolInject<LevelComponent> _levelPool = default;

        public void Init(IEcsSystems ecsSystems)
        {
            var levelEntity = _world.Value.NewEntity();

            _levelPool.Value.Add(levelEntity);
            ref LevelComponent levelCompanent = ref _levelPool.Value.Get(levelEntity);

            var levelResources = Resources.Load<GameObject>(LevelsAssetsPath.LevelsPath
                [_sharedInject.Value.LevelType]);
            var levelGameObject = Object.Instantiate(levelResources);

            levelCompanent.LevelTransform = levelGameObject.transform;
            levelCompanent.RespawnTransform = GameObject.FindGameObjectWithTag(TagManager.RESPAWN).transform;
            _sharedInject.Value.PlayerRespawnTransform = levelCompanent.RespawnTransform;

        }
    }
}
