using UnityEngine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using EcsRunner.Data;
using EcsRunner.Components;


namespace EcsRunner.Systems
{
    class CameraInitSystem : IEcsInitSystem
    {
        private readonly EcsWorldInject _world = default;
        private readonly EcsSharedInject<GameData> _sharedInject = default;

        private readonly EcsPoolInject<CameraComponent> _cameraPool = default;

        public void Init(IEcsSystems ecsSystems)
        {
            var cameraEntity = _world.Value.NewEntity();
            _cameraPool.Value.Add(cameraEntity);
            ref var cameraComponent = ref _cameraPool.Value.Get(cameraEntity);

            cameraComponent.CurrentVelocity = Vector3.zero;
            cameraComponent.CameraTransform = Camera.main.transform;
            cameraComponent.Offset = _sharedInject.Value.CameraData.Offset;
            cameraComponent.CameraSmoothness = _sharedInject.Value.CameraData.CameraSmoothness;
        }
    }
}
