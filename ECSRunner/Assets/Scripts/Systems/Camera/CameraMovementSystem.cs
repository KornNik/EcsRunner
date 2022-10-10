using UnityEngine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using EcsRunner.Components;

namespace EcsRunner.Systems
{
    class CameraMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<PlayerComponent>> _playerFilter = default;
        private readonly EcsFilterInject<Inc<CameraComponent>> _cameraFilter = default;

        private readonly EcsPoolInject<PlayerComponent> _playerPool = default;
        private readonly EcsPoolInject<CameraComponent> _cameraPool = default;

        public void Run(IEcsSystems ecsSystems)
        {
            foreach (var playerEntity in _playerFilter.Value)
            {
                foreach (var cameraEntity in _cameraFilter.Value)
                {
                    ref PlayerComponent playerComponent = ref _playerPool.Value.Get(playerEntity);
                    ref CameraComponent cameraComponent = ref _cameraPool.Value.Get(cameraEntity);

                    Vector3 currentPosition = cameraComponent.CameraTransform.position;
                    Vector3 targetPoint = playerComponent.PlayerTransform.position + cameraComponent.Offset;

                    var desiredPosition = targetPoint + cameraComponent.Offset;
                    cameraComponent.CameraTransform.position = Vector3.SmoothDamp(currentPosition, desiredPosition,
                        ref cameraComponent.CurrentVelocity, cameraComponent.CameraSmoothness);
                    cameraComponent.CameraTransform.LookAt(targetPoint);
                }
            }
        }
    }
}
