using EcsRunner.Data;
using EcsRunner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsRunner.Systems
{
    class CoinInitSystem : IEcsInitSystem
    {
        private readonly EcsWorldInject _world = default;
        private readonly EcsSharedInject<GameData> _sharedInject = default;

        private readonly EcsPoolInject<CoinComponent> _coinPool = default;

        public void Init(IEcsSystems ecsSystems)
        {
            var coinEntity = _world.Value.NewEntity();

            _coinPool.Value.Add(coinEntity);
            ref CoinComponent coinComponent = ref _coinPool.Value.Get(coinEntity);

            coinComponent.Points = _sharedInject.Value.CoinData.CoinPoints;
        }
    }
}
