using UnityEngine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using EcsRunner.Data;
using EcsRunner.Helpers;
using EcsRunner.Components;

namespace EcsRunner.Systems
{
    class CoinHitSystem : IEcsRunSystem
    {
        private readonly EcsSharedInject<GameData> _sharedInject = default;

        private readonly EcsFilterInject<Inc<PlayerComponent>> _playerFilter = default;
        private readonly EcsFilterInject<Inc<ScoreComponent>> _scoreFilter = default;

        private readonly EcsPoolInject<PlayerComponent> _playerPool = default;
        private readonly EcsPoolInject<ScoreComponent> _scorePool = default;

        public void Run(IEcsSystems ecsSystems)
        {
            foreach (var entity in _playerFilter.Value)
            {
                foreach (var scoreEntity in _scoreFilter.Value)
                {
                    ref PlayerComponent player = ref _playerPool.Value.Get(entity);
                    ref ScoreComponent score = ref _scorePool.Value.Get(scoreEntity);

                    if (Physics.Raycast(player.PlayerTransform.position, player.PlayerTransform.forward,
                        out RaycastHit hitInfo, 0.2f, LayerManager.CoinLayer))
                    {
                        hitInfo.transform.gameObject.SetActive(false);
                        score.Score += _sharedInject.Value.CoinData.CoinPoints;
                        score.ScoreText.text = score.Score.ToString();
                    }
                }

            }
        }
    }
}
