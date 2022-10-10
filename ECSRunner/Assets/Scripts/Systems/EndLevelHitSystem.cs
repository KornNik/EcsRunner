using UnityEngine;
using EcsRunner.Data;
using EcsRunner.Helpers;
using EcsRunner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsRunner.Systems
{
    class EndLevelHitSystem : IEcsRunSystem
    {
        private readonly EcsSharedInject<GameData> _sharedInject = default;

        private readonly EcsFilterInject<Inc<PlayerComponent>> _playerFilter = default;

        private readonly EcsPoolInject<PlayerComponent> _playerPool = default;

        public void Run(IEcsSystems ecsSystems)
        {
            foreach (var entity in _playerFilter.Value)
            {
                ref PlayerComponent player = ref _playerPool.Value.Get(entity);

                if (Physics.Raycast(player.PlayerTransform.position, player.PlayerTransform.forward,
                    0.2f, LayerManager.FinishLayer))
                {
                    _sharedInject.Value.EndLevelPanel.gameObject.SetActive(true);
                    player.PlayerTransform.gameObject.SetActive(false);
                    ecsSystems.GetWorld().DelEntity(entity);
                }
            }
        }
    }
}
