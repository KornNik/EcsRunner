using UnityEngine;
using EcsRunner.Data;
using EcsRunner.Helpers;
using EcsRunner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsRunner.Systems
{
    class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorldInject _world = default;
        private readonly EcsSharedInject<GameData> _sharedInject = default;

        private readonly EcsPoolInject<InputCompanent> _inputPool = default;
        private readonly EcsPoolInject<MoveCompanent> _movablePool = default;
        private readonly EcsPoolInject<PlayerComponent> _playerPool = default;
        private readonly EcsPoolInject<CharacterAnimationCompanent> _characterAnimationPool = default;

        public void Init(IEcsSystems ecsSystems)
        {
            var playerEntity = _world.Value.NewEntity();

            _playerPool.Value.Add(playerEntity);
            ref PlayerComponent playerComponent = ref _playerPool.Value.Get(playerEntity);

            _inputPool.Value.Add(playerEntity);
            ref InputCompanent playerInputComponent = ref _inputPool.Value.Get(playerEntity);

            _movablePool.Value.Add(playerEntity);
            ref MoveCompanent playerMovableCompanent = ref _movablePool.Value.Get(playerEntity);

            _characterAnimationPool.Value.Add(playerEntity);
            ref CharacterAnimationCompanent playerAnimationCompanent =
                ref _characterAnimationPool.Value.Get(playerEntity);

            var playerResources = Resources.Load<GameObject>(PlayerAssetsPath.PlayersPath
                [_sharedInject.Value.PlayerType]);
            var playerGameObject = GameObject.Instantiate(playerResources,
                _sharedInject.Value.PlayerRespawnTransform.position,
                _sharedInject.Value.PlayerRespawnTransform.rotation);

            playerGameObject.transform.position = _sharedInject.Value.PlayerRespawnTransform.position;
            playerGameObject.transform.rotation = _sharedInject.Value.PlayerRespawnTransform.rotation;

            playerComponent.PlayerTransform = playerGameObject.transform;
            playerComponent.Rigidbody = playerGameObject.GetComponent<Rigidbody>();

            playerMovableCompanent.MoveSpeed = _sharedInject.Value.MoveData.MovingSpeed;
            playerMovableCompanent.CharacterController = playerGameObject.GetComponent<CharacterController>();

            playerAnimationCompanent.Animator = playerGameObject.GetComponent<Animator>();
        }
    }
}
