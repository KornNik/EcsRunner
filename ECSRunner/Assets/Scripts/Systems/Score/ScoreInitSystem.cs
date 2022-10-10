using EcsRunner.Data;
using EcsRunner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsRunner.Systems
{
    class ScoreInitSystem : IEcsInitSystem
    {
        private readonly EcsWorldInject _world = default;
        private readonly EcsSharedInject<GameData> _sharedInject = default;

        private readonly EcsPoolInject<ScoreComponent> _scorePool = default;

        public void Init(IEcsSystems ecsSystems)
        {
            var scoreEntity = _world.Value.NewEntity();

            _scorePool.Value.Add(scoreEntity);
            ref ScoreComponent scoreComponent = ref _scorePool.Value.Get(scoreEntity);

            scoreComponent.Score = 0;
            scoreComponent.ScoreText = _sharedInject.Value.ScoreText;
            scoreComponent.ScoreText.text = scoreComponent.Score.ToString();
        }
    }
}
