using EcsRunner.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Unity.Ugui;

namespace EcsRunner.Systems
{
    class GameInit
    {
        private EcsWorld _world = null;
        private GameData _gameData;
        private EcsUguiEmitter _emitter;

        private IEcsSystems _initSystems;
        private IEcsSystems _updateSystems;
        private IEcsSystems _fixedUpdateSystems;

        public GameInit(GameData gameData, EcsUguiEmitter emitter)
        {
            _gameData = gameData;
            _emitter = emitter;

            Initialization();
        }

        public void Initialization()
        {
            _world = new EcsWorld();

            _initSystems = new EcsSystems(_world, _gameData);
            _initSystems.Add(new LevelInitSystem());
            _initSystems.Add(new PlayerInitSystem());
            _initSystems.Add(new CameraInitSystem());
            _initSystems.Add(new CoinInitSystem());
            _initSystems.Add(new ScoreInitSystem());
            _initSystems.Inject();
            _initSystems.Init();

            _updateSystems = new EcsSystems(_world, _gameData);
            _updateSystems.Add(new PlayerInputKeyboardSystem());
            _updateSystems.Add(new PlayerAnimationSystem());
            _updateSystems.Add(new ButtonInputSystem());
            _updateSystems.Add(new SwipeInputSystem());
            _updateSystems.Add(new NextLevelButtonSystem());
            _updateSystems.Inject();
            _updateSystems.InjectUgui(_emitter);
            _updateSystems.Init();

            _fixedUpdateSystems = new EcsSystems(_world, _gameData);
            _fixedUpdateSystems.Add(new MovementSystem());
            _fixedUpdateSystems.Add(new CameraMovementSystem());
            _fixedUpdateSystems.Add(new CoinHitSystem());
            _fixedUpdateSystems.Add(new EndLevelHitSystem());
            _fixedUpdateSystems.Inject();
            _fixedUpdateSystems.Init();
        }

        public void UpdateSystems()
        {
            _updateSystems.Run();
        }
        public void FixedUpdateSystems()
        {
            _fixedUpdateSystems.Run();
        }
        public void Destroy()
        {
            _initSystems.Destroy();
            _updateSystems.Destroy();
            _fixedUpdateSystems.Destroy();
            _initSystems = null;
            _updateSystems = null;
            _fixedUpdateSystems = null;

            _world.Destroy();
            _world = null;
        }
    }
}
